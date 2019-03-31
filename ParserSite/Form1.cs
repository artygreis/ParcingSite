using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Abot.Crawler;
using Abot.Poco;
using log4net;
using log4net.Config;

using Npgsql;

namespace ParserSite
{
    public partial class frmMain : Form
    {
        //строка подключения к БД
        string connString = "Host=localhost;Username=postgres;Password=123456;Database=parserpage";

        //добавление информации в блок Лог
        private void AddTextLog(string str)
        {
            txtLog.AppendText(str + "\r\n");
        }

        //обработка запросов для выборки данных
        private DataTable DataTableResult(string stsql)
        {

                using (var conn = new NpgsqlConnection(connString))
                {
                    DataSet ds = new DataSet();
                    conn.Open();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(stsql, conn);
                    da.Fill(ds);
                    conn.Close();
                    return ds.Tables[0];
                }
        }

        //настройка отображения записей в DataGridView
        private void SetSettingsDataGrid()
        {
            dgvDataPages.Columns[0].HeaderText = "ID";
            dgvDataPages.Columns[1].HeaderText = "Заголовок статьи";
            dgvDataPages.Columns[2].HeaderText = "Ссылка на статью";
            dgvDataPages.Columns[0].Width = 50;
            dgvDataPages.Columns[1].Width = 200;
            dgvDataPages.Columns[2].Width = 200;
            dgvDataPages.Sort(dgvDataPages.Columns[0], ListSortDirection.Ascending);

        }

        public frmMain()
        {
            InitializeComponent();

            dgvDataPages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDataPages.AllowUserToAddRows = false;
            dgvDataPages.AllowUserToResizeColumns = false;
        }


        //обработка страниц
        private void crawler_ProcessPageCrawlCompletedAsync(object sender, PageCrawlCompletedArgs e)
        {
            CrawledPage crawledPage = e.CrawledPage;
            var htmlAgilityPackDocument = crawledPage.HtmlDocument;
            htmlAgilityPackDocument.LoadHtml(crawledPage.Content.Text);
            var nodes = htmlAgilityPackDocument.DocumentNode.SelectNodes("//div[@class='news-detail']");
            if (nodes != null)
                foreach (var node in nodes)
                {
                    if (node.SelectSingleNode("./h1[@class='name']") != null)
                        Page.SetpageArticleName(node.SelectSingleNode("./h1[@class='name']").InnerText.Trim());
                    else
                        continue;
                    if (crawledPage.Uri.ToString() != null)
                        Page.pageUrl = crawledPage.Uri.ToString();
                    else
                        continue;
                    if (node.SelectSingleNode("./div[@class='detail_text'][1]") != null &&
                        node.SelectSingleNode("./div[@class='detail_text'][3]") != null)
                        Page.SetpageArticleText(node.SelectSingleNode("./div[@class='detail_text'][1]").InnerText +
                            node.SelectSingleNode("./div[@class='detail_text'][3]").InnerText);
                    else
                        continue;
                    if (crawledPage.Content.Text != null)
                    {
                        Page.SetpageAllHtml(crawledPage.Content.Text);
                    }
                    else
                        continue;
                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();

                        // Вставка данных в БД
                        using (var cmd = new NpgsqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = "INSERT INTO pages(pagearticlename, pageurl, pagearticletext, pageallhtml)" +
                                " VALUES (@pagearticlename, @pageurl, @pagearticletext, @pageallhtml)";
                            cmd.Parameters.AddWithValue("pagearticlename", Page.GetpageArticleName());
                            cmd.Parameters.AddWithValue("pageurl", Page.pageUrl);
                            cmd.Parameters.AddWithValue("pagearticletext", Page.GetpageArticleText());
                            cmd.Parameters.AddWithValue("pageallhtml", Page.GetpageAllHtml());
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                    this.Invoke(new Action(() =>
                    {
                        AddTextLog("Обработана страница: " + Page.pageUrl + "; Название статьи: " + Page.GetpageArticleName());
                    }));
                    
                }
        }

        //запуск парсинга
        private void btnParser_Click(object sender, EventArgs e)
        {
            AddTextLog("Сканирование запущено. Ожидайте...");
            XmlConfigurator.Configure();
            Task.Run(() => StartParcing()); //запуск парсинга в отдельной задаче
        }

        //загрузка настроек сканирования и переопределение количства сканируемых страниц
        private IWebCrawler GetDefaultWebCrawler()
        {
            CrawlConfiguration config = new CrawlConfiguration();
            config.MaxPagesToCrawl = Convert.ToInt32(numPagesToCrawl.Value);
            return new PoliteWebCrawler(config, null, null, null, null, null, null, null, null);
        }

        //метод для запуска парсинга
        private void StartParcing()
        {
            IWebCrawler crawler;
            crawler = GetDefaultWebCrawler();
            crawler = GetCustomBehaviorUsingLambdaWebCrawler();

            crawler.PageCrawlCompletedAsync += crawler_ProcessPageCrawlCompletedAsync;

            CrawlResult result = crawler.Crawl(new Uri("https://belaruspartisan.by/"));

            if (result.ErrorOccurred == false)
            {
                this.Invoke(new Action(() =>
                {
                    AddTextLog("Скнирование завершено успешно!");
                }));
            }
        }

        //исключение страниц, которые находятся в разделе Мобильная версия сайта 
        //и имеют адрес https://belaruspartisan.by/m/
        private IWebCrawler GetCustomBehaviorUsingLambdaWebCrawler()
        {
            IWebCrawler crawler = GetDefaultWebCrawler();

            crawler.ShouldCrawlPage((pageToCrawl, crawlContext) =>
            {
                if (pageToCrawl.Uri.AbsoluteUri.Contains("m"))
                    return new CrawlDecision { Allow = false, Reason = "Scared of ghosts" };

                return new CrawlDecision { Allow = true };
            });
            return crawler;
        }

        #region Работа с БД
        //загрузка данных из БД
        private void btnLoadFromDb_Click(object sender, EventArgs e)
        {
            string stsql = "SELECT id, pagearticlename, pageurl FROM pages";
            dgvDataPages.DataSource = DataTableResult(stsql);
            AddTextLog("Таблица загружена... Найдено " + dgvDataPages.RowCount.ToString() + " записей.");
            SetSettingsDataGrid();
        }
        //очистка БД
        private void btnClearDb_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                DataSet ds = new DataSet();
                conn.Open();
                string stsql = "DELETE FROM pages";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(stsql, conn);
                da.Fill(ds);
                conn.Close();
            }
            AddTextLog("База данных очищена!");
        }
        //поиск статьи по заданному слову, которое вводится в текстовое поле
        private void btnFindPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFindPage.Text != "")
                {
                    string stsql = "SELECT id, pagearticlename, pageurl FROM pages " +
                            "WHERE pagearticletext LIKE '%" + txtFindPage.Text + "%'";
                    dgvDataPages.DataSource = DataTableResult(stsql);
                    AddTextLog("Найдено " + dgvDataPages.RowCount.ToString() + " записей.");
                    SetSettingsDataGrid();
                }
                else
                    MessageBox.Show("Введите условие для поиска!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Работа с записями из БД
        //просмотр HTML текста страницы в форме Дополнительная информация (ShowMore)
        private void btnShowHtml_Click(object sender, EventArgs e)
        {
            try
            {
                string stsql = "SELECT pageallhtml FROM pages " +
                        "WHERE pagearticlename LIKE '" + dgvDataPages.CurrentRow.Cells[1].Value.ToString() + "'";
                string textHtml = DataTableResult(stsql).Rows[0][0].ToString();
                ShowMore newForm = new ShowMore(textHtml);
                newForm.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //просмотр текста страницы в форме Дополнительная информация (ShowMore)
        private void btnShowArticle_Click(object sender, EventArgs e)
        {
            try
            {
                string stsql = "SELECT pageArticleText FROM pages " +
                    "WHERE pagearticlename LIKE '" + dgvDataPages.CurrentRow.Cells[1].Value.ToString() + "'";
                string textHtml = DataTableResult(stsql).Rows[0][0].ToString();
                ShowMore newForm = new ShowMore(textHtml);
                newForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //открыть статью в браузере
        private void btnOpenUrl_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(dgvDataPages.CurrentRow.Cells[2].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    #endregion
}
