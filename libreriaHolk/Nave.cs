using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cupertino_bot.libreriaHolk
{
    internal class Nave
    {
        IWebDriver driver;
        public String idChromeOriginalP;


        //Iniciar Navegador y maximizar pantalla---------------------------------------
        public void OpenUrl(String Url)
        {
            try
            {

                Console.WriteLine("Intentando abrir la URL: " + Url);
                //descargas

                //chromeOptions.AddUserProfilePreference("download.default_directory", @"C:\lili\"+ ruta01);
                /*
                //driver = new 
                ChromeDriverService Service;
                Service = ChromeDriverService.CreateDefaultService();
                //Service.HideCommandPromptWindow = true;
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--start-maximized");
                options.AddArguments("--lang=es");
                //options.AddArguments("--headless");//ocultar navegador
                options.AddArguments("--disable-popup-blocking");
                options.AddArguments("--disable-notifications");
                options.AddArguments("--disable-md-downloads");
                options.AddArguments("--disable-infobars");
                options.AddArguments("--allow-running-insecure-content");
                options.AddArguments("--safebrowsing-disable-download-protection");
                options.AddArguments("--safebrowsing-disable-extension-blacklist");
                options.AddUserProfilePreference("safebrowsing.enabled", true);
                options.AddUserProfilePreference("download.directory_upgrade", true);
                options.AddUserProfilePreference("download.default_directory", @"C:\holk\data");
                options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
                options.AddUserProfilePreference("download.prompt_for_download", false);
                options.AddAdditionalCapability("useAutomationExtension", false);*/

                //WebDriver driver = new ChromeDriver();
                //driver = new ChromeDriver(Service, options);

                driver = new ChromeDriver();



                //descargas fin
                driver.Manage().Window.Maximize();
                Console.WriteLine("maximizando navegador");
                driver.Navigate().GoToUrl(Url);
                idChromeOriginalP = driver.CurrentWindowHandle;
                Console.WriteLine("Se abrir con exito la URL: " + Url + " Id pagina " + idChromeOriginalP);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error abriendo navegador: " + e);

            }

        }
        //octener identificador de pagina actual
        public String identiVenta()
        {

            return driver.CurrentWindowHandle;

        }


        //abre una nueva ventana y da el identificador unico
        public String abrirPest(String UrlP)
        {
            string taplWindow;

            try
            {
                tiempoE(2);
                ((IJavaScriptExecutor)driver).ExecuteScript("window.open('','_blank');");
                //taplWindow = driver.CurrentWindowHandle;
                Console.WriteLine("Se abrio una nueva pestaña: " + driver.Title);
                driver.Navigate().GoToUrl(UrlP);
                taplWindow = "Error25";

                //Loop through until we find a new window handle
                foreach (string window in driver.WindowHandles)
                {
                    if (idChromeOriginalP != window)
                    {
                        driver.SwitchTo().Window(window);
                        Console.WriteLine("Correcto------------: " + driver.Title + " -- " + driver.CurrentWindowHandle);
                        taplWindow = driver.CurrentWindowHandle;
                        break;


                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Error abriendo nueva pestaña del navegador: " + e);
                taplWindow = "Error26";
            }

            return taplWindow;
        }

        public String dosPestañas(String url2)
        {
            string taplWindow;

            try
            {
                tiempoE(2);
                ((IJavaScriptExecutor)driver).ExecuteScript("window.open('" + url2 + "','_blank');");
                //taplWindow = driver.CurrentWindowHandle;
                Console.WriteLine("Se abrio una nueva pestaña: " + driver.Title);
                //driver.Navigate().GoToUrl(url2); //abrir url en pestaña actual
                nextVentana();
                taplWindow = driver.CurrentWindowHandle;


            }
            catch (Exception e)
            {
                Console.WriteLine("Error abriendo nueva pestaña del navegador: " + e);
                taplWindow = "Error26";
            }

            return taplWindow;

        }

        public void NewVentana()
        {
            int cont = 0;

            try
            {
                string originalWindow = driver.CurrentWindowHandle;
                //Loop through until we find a new window handle
                foreach (string window in driver.WindowHandles)
                {
                    cont++;
                    if (originalWindow != window)
                    {
                        driver.SwitchTo().Window(window);
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error nexVentana " + e);

            }



        }
        // se agrega el id del frame solo el id "ejemplo_id"
        public void CambiarFrameId(string Id)
        {
            try
            {
                driver.SwitchTo().Frame(Id);
            }
            catch (Exception e)
            {

                Console.WriteLine("Frame -> " + Id + " no seleccionado: " + e);
            }

        }

        public void CambiarFrameXp(string XP)
        {
            try
            {
                driver.SwitchTo().Frame(driver.FindElement(By.XPath(XP)));
                Console.WriteLine("Frame -> " + XP + " ha sido cambiado");
            }
            catch (Exception e)
            {
                Console.WriteLine("Frame -> " + XP + " no seleccionado: " + e);
            }
        }

        public void cambiarPestana(String idPestaña)
        {
            try
            {
                driver.SwitchTo().Window(idPestaña);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error al cambiar pestaña " + e);
                nextVentana();//Eliminar para usar mas de dos pestañas

            }

        }

        public void CambiarFrameCss(string Css)
        {
            try
            {
                driver.SwitchTo().Frame(driver.FindElement(By.CssSelector(Css)));
            }
            catch (Exception e)
            {

                Console.WriteLine("CambiarFrameCss " + e);
            }
        }

        //click en un Xpath----------------------------------
        public void ClickXP(string XP)
        {
            try
            {
                driver.FindElement(By.XPath(XP)).Click();
                Console.WriteLine("click: " + XP);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error ClickXP: " + XP + "\n -Detalles: " + e);
            }
        }

        //Click para limpiar texto
        public void ClearXP(string XP)
        {
            try
            {
                driver.FindElement(By.XPath(XP)).Clear();
                Console.WriteLine("Se limpio el XP -------->" + XP);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al limpiar XP: " + e);
            }
        }

        //Extraer textos Value caja de textos
        public String TexV(String XP)
        {
            String melo = " ";
            try
            {
                melo = driver.FindElement(By.XPath(XP)).GetAttribute("value");
                Console.WriteLine("control1 value: " + melo);
                return melo;

            }
            catch (Exception e)
            {
                Console.WriteLine("error en " + XP + "\n -Detalles:" + e);
                return melo;
            }

        }

        //minimizar ventana o maximizar
        public void MinVentana()
        {
            driver.Manage().Window.Minimize();
        }

        //MAximizar ventana
        public void MaxVentana()
        {
            try
            {
                driver.Manage().Window.Maximize();

            }
            catch (Exception e)
            {

                Console.WriteLine("Error al maximizar ventana " + e);
            }

        }
        //Extraer textos h1 h2 p etc
        public String TexT(String XP)
        {
            String melo = " ";
            try
            {
                melo = driver.FindElement(By.XPath(XP)).Text;
                Console.WriteLine("Extraer TexT: " + melo);
                return melo;

            }
            catch (Exception)
            {
                Console.WriteLine("Error: Extraer textos h1 h2 p etc" + XP);
                return melo;
            }

        }




        //Escribir textos Xpath-------------------------------------
        public void EscribirText(String xpath1, string texto)
        {
            try
            {
                //Thread.Sleep(3000);
                driver.FindElement(By.XPath(xpath1)).SendKeys(texto);
                Console.WriteLine("Ejecuto EscribirTexto: " + texto);


            }
            catch (Exception e)
            {
                Console.WriteLine("Error al Escribir: " + e);
            }
        }

        public void EscribirNum(String xpath1, int num)
        {
            try
            {

                driver.FindElement(By.XPath(xpath1)).SendKeys(num.ToString());
                Console.WriteLine("Ejecuto EscribirTexto: " + num.ToString());


            }
            catch (Exception e)
            {
                Console.WriteLine("Error al Escribir: " + e);
            }
        }

        //Tiempo de espera ---------------------------------------
        public void tiempoE(int tm)
        {
            Thread.Sleep(tm * 1000);
        }

        //espera la nueva ventana
        public void esperaVentana()
        {
            driver.SwitchTo().NewWindow(WindowType.Window);

        }

        //Verifica si un objeto es visible-------------------------
        public bool IsVisible(string Obj)
        {

            try
            {

                if (driver.FindElement(By.XPath(Obj)).Displayed)
                {
                    Console.WriteLine("Está visible: " + Obj);
                    return true;
                }
                else
                {
                    Console.WriteLine("No está visible: " + Obj);
                    return false;
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Error en IsVisible: " + Obj);
                return false;

            }
            //ejemplo de uso
            //while (on1.IsVisible("//input[@id='email2']") == false) { on1.tiempoE(2); }

        }

        public void salir()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {

                Console.WriteLine("Error al cerrar navegador");
            }

        }

        public void cerrarVentana()
        {
            //Close the tab or window
            driver.Close();

            //Switch back to the old tab or window
            driver.SwitchTo().Window(idChromeOriginalP);
        }

        //retroceder una pagina
        public void indexBack()
        {
            driver.Navigate().Back();
        }

        //
        public void nextVentana()
        {
            try
            {
                //Store the ID of the original window
                string originalWindow = driver.CurrentWindowHandle;
                Console.WriteLine("Venta Original: " + originalWindow);
                //Loop through until we find a new window handle
                foreach (string window in driver.WindowHandles)
                {
                    if (originalWindow != window)
                    {
                        driver.SwitchTo().Window(window);
                        Console.WriteLine("Venta a la que se salta: " + window);
                        break;
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine("Error a la siguiente ventana: " + e);
            }

        }

        //Valida la existencia de una ruta o archivo y devuelve un true o false
        public bool ValidarRutaExiste(string path)
        {
            if (File.Exists(path))
            {
                // This path is a file
                Console.WriteLine("{0} Archivo existe", path);
                return true;
            }
            else if (Directory.Exists(path))
            {
                // This path is a directory
                Console.WriteLine("{0} Ruta existe", path);
                return true;

            }
            else
            {
                Console.WriteLine("{0} Ruta o archivo no existe", path);
                return false;
            }
        }

        public void CambiarFrame(string InnerId)
        {
            try
            {
                driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@innerid='" + InnerId + "']")));
                Console.WriteLine("Frame -> " + InnerId + " ha sido cambiado");
            }
            catch (Exception e)
            {
                Console.WriteLine("Frame -> " + InnerId + " no seleccionado: " + e);
            }

        }

        //RESETEA EL FRAMEN
        public void RestFrame()
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                Console.WriteLine("Reseteado Frame");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al Resetear Frame: " + e);
            }

        }

        //cambio de tamaño temporal
        public void cambioDeTT()
        {
            driver.Manage().Window.Size = new Size(724, 768);
            tiempoE(3);
            driver.Manage().Window.Maximize();
        }



        public int ConcatInt2(int x, int y)
        {
            return (int)(x * Math.Pow(10, y.ToString().Length)) + y;
        }

        //Escribe en un block de notas
        public void EscribirBlog(String nombreA, String texto)
        {

            string path = nombreA;
            try
            {
                File.AppendAllLines(path, new String[] { texto });
            }
            catch (Exception e)
            {

                Console.WriteLine("error en la ruta: " + e);
            }

        }
        // ABRIR VENTANA ULTIMA VERSION SELENIUM
        public string nuevaVentanaX(string NUrl)
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);
            driver.Navigate().GoToUrl(NUrl);
            String holagg = driver.CurrentWindowHandle;
            return holagg;

        }

        public void CerrarPestaña(string pestana)
        {
            try
            {
                driver.SwitchTo().Window(pestana);
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }


        }


        public void EliminarArchivo(string Directorio)
        {
            if (File.Exists(@Directorio))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    File.Delete(@Directorio);
                    Console.WriteLine("Se elimino el archivo" + @Directorio);
                }
                catch (IOException e)
                {
                    Console.WriteLine("Eliminar:  " + e.Message);
                    return;
                }
            }
        }

        public void NaveAtras()
        {
            driver.Navigate().Back();
        }

        public void RefreshVentana()
        {

            driver.Navigate().Refresh();


        }

        public void SelectXP(string XP, string nombre)
        {

            try
            {
                IWebElement selectElement = driver.FindElement(By.XPath(XP));
                var selectObject = new SelectElement(selectElement);

                selectObject.SelectByText(nombre);

            }
            catch (Exception e)
            {

                Console.WriteLine("SelectXP Error: XP " + XP + " Nombre: " + nombre);
                Console.WriteLine("inf---- " + e);
            }



        }

        public IReadOnlyList<IWebElement> MultiplesElementos(string elemeto333)
        {

            IReadOnlyList<IWebElement> muchoCheese = driver.FindElements(By.CssSelector("#cheese li"));

            return muchoCheese;


        }
    }
}
