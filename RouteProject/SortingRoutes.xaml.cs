using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RouteProject
{
    /// <summary>
    /// Interaction logic for SortingRoutes.xaml
    /// </summary>
    public partial class SortingRoutes : Window
    {
        // Adatbázis csatlakozás
        static Random rnd = new Random();
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("projectLabRoutes");   // Adatbázis neve
        static IMongoCollection<Routes> collection = db.GetCollection<Routes>("routes"); // Collection, táblázat

        public void ReadAllDocuments()
        {
            List<Routes> list = collection.AsQueryable().ToList<Routes>();


            dtGrdSort.ItemsSource = list;
           Routes r = (Routes)dtGrdSort.Items.GetItemAt(0);
            

        }

        public int[] tmbArray;
        public void SwitchCase()
        {

            int rndSortCount =  rnd.Next(2, 8);  //2 től 7 ig kiválaszt egy db számot

            tmbArray = new int[rndSortCount];
            List<Routes> list = collection.AsQueryable().ToList<Routes>();
            List<int> tryRepeat = new List<int>();
            int nmb;

            //  Leszűri az ismétlődéseket
            for (int i = 0; i < rndSortCount; i++)
            {
                do
                {
                    nmb = rnd.Next(0,  list.Count() );
                } while (tryRepeat.Contains(nmb));
                tryRepeat.Add(nmb);
            }

                btn1.Content = list[tryRepeat[0]].number;
                btn2.Content = list[tryRepeat[1]].number;
          
                // Ahány db számot akarunk megkapni azt tölti be, és adja át neki a random index számát
                switch (rndSortCount)
                {
                case 3:
                btnThird.IsEnabled = true;
                txtBox3.Visibility = Visibility.Visible;
                btn3.IsEnabled = true;
                btn3.Content = list[tryRepeat[2]].number;
                break;
                case 4:
                btnThird.IsEnabled = true;
                btnFourth.IsEnabled = true;
                txtBox3.Visibility = Visibility.Visible;
                txtBox4.Visibility = Visibility.Visible;
                btn3.IsEnabled = true;
                btn4.IsEnabled = true;
                btn3.Content = list[tryRepeat[2]].number;
                btn4.Content = list[tryRepeat[3]].number;
                break;
                case 5:
                btnThird.IsEnabled = true;
                btnFourth.IsEnabled = true;
                btnFifth.IsEnabled = true;
                txtBox3.Visibility = Visibility.Visible;
                txtBox4.Visibility = Visibility.Visible;
                txtBox5.Visibility = Visibility.Visible;
                btn3.IsEnabled = true;
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
                btn3.Content = list[tryRepeat[2]].number;
                btn4.Content = list[tryRepeat[3]].number;
                btn5.Content = list[tryRepeat[4]].number;
                break;
                case 6:
                btnThird.IsEnabled = true;
                btnFourth.IsEnabled = true;
                btnFifth.IsEnabled = true;
                btnSixth.IsEnabled = true;
                txtBox3.Visibility = Visibility.Visible;
                txtBox4.Visibility = Visibility.Visible;
                txtBox5.Visibility = Visibility.Visible;
                txtBox6.Visibility = Visibility.Visible;
                btn3.IsEnabled = true;
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
                btn6.IsEnabled = true;
                btn3.Content = list[tryRepeat[2]].number;
                btn4.Content = list[tryRepeat[3]].number;
                btn5.Content = list[tryRepeat[4]].number;
                btn6.Content = list[tryRepeat[5]].number;
                break;
                case 7:
                btnThird.IsEnabled = true;
                btnFourth.IsEnabled = true;
                btnFifth.IsEnabled = true;
                btnSixth.IsEnabled = true;
                btnSeventh.IsEnabled = true;
                txtBox3.Visibility = Visibility.Visible;
                txtBox4.Visibility = Visibility.Visible;
                txtBox5.Visibility = Visibility.Visible;
                txtBox6.Visibility = Visibility.Visible;
                txtBox7.Visibility = Visibility.Visible;
                btn3.IsEnabled = true;
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
                btn6.IsEnabled = true;
                btn7.IsEnabled = true;
                btn3.Content = list[tryRepeat[2]].number;
                btn4.Content = list[tryRepeat[3]].number;
                btn5.Content = list[tryRepeat[4]].number;
                btn6.Content = list[tryRepeat[5]].number;
                btn7.Content = list[tryRepeat[6]].number;
                break;
                default:
                break;

                }

        }

       
        public SortingRoutes()
        {
            InitializeComponent();
            ReadAllDocuments(); // Indításkor betölti az adatokat
            SwitchCase(); // Random index számait betölti a gombokra
        }


        public void indexIs()
        {

            // Ha behúzom valahova a számokat, akkor futnak le (Label megjelenik, és elmenti a tömbbe a számot)
                if (txtBox1.Text != "" && btn1.Content != "")
                {
                    int firstNumbr = Convert.ToInt32(btn1.Content);
                    int firstNmbrIndx = int.Parse(txtBox1.Text) - 1;
                    tmbArray[firstNmbrIndx] = firstNumbr;

                txtBox1.IsEnabled = false;
                lblAfter1.Visibility = Visibility.Visible;
                lblTxt1.Visibility = Visibility.Visible; lblTxt1.Content = tmbArray[0].ToString(); 
                 }

                if (txtBox2.Text != "" && btn2.Content != "")
                {
                    int secondNumbr = Convert.ToInt32(btn2.Content);
                    int secondNmbrIndx = int.Parse(txtBox2.Text) - 1;
                    tmbArray[secondNmbrIndx] = secondNumbr;

                txtBox2.IsEnabled = false;
                lblAfter1.Visibility = Visibility.Visible;
                lblAfter2.Visibility = Visibility.Visible;
                lblTxt1.Visibility = Visibility.Visible; lblTxt1.Content = tmbArray[0].ToString();
                lblTxt2.Visibility = Visibility.Visible; lblTxt2.Content = tmbArray[1].ToString();
            }
            if (txtBox3.Text != "" && btn3.Content != "")
                {
                    int thirdNmbr = Convert.ToInt32(btn3.Content);
                    int thirdNmbrIndx = int.Parse(txtBox3.Text) - 1;
                    tmbArray[thirdNmbrIndx] = thirdNmbr;

                txtBox3.IsEnabled = false;
                lblAfter1.Visibility = Visibility.Visible;
                lblAfter2.Visibility = Visibility.Visible;
                lblAfter3.Visibility = Visibility.Visible;
                lblTxt1.Visibility = Visibility.Visible; lblTxt1.Content = tmbArray[0].ToString();
                lblTxt2.Visibility = Visibility.Visible; lblTxt2.Content = tmbArray[1].ToString();
                lblTxt3.Visibility = Visibility.Visible; lblTxt3.Content = tmbArray[2].ToString();

            }
            if (txtBox4.Text != "" && btn4.Content != "")
                {
                    int fourthNumbr = Convert.ToInt32(btn4.Content);
                    int fourhtNmbrIndx = int.Parse(txtBox4.Text) - 1;
                    tmbArray[fourhtNmbrIndx] = fourthNumbr;

                txtBox4.IsEnabled = false;
                lblAfter1.Visibility = Visibility.Visible;
                lblAfter2.Visibility = Visibility.Visible;
                lblAfter3.Visibility = Visibility.Visible;
                lblAfter4.Visibility = Visibility.Visible;
                lblTxt1.Visibility = Visibility.Visible; lblTxt1.Content = tmbArray[0].ToString();
                lblTxt2.Visibility = Visibility.Visible; lblTxt2.Content = tmbArray[1].ToString();
                lblTxt3.Visibility = Visibility.Visible; lblTxt3.Content = tmbArray[2].ToString();
                lblTxt4.Visibility = Visibility.Visible; lblTxt4.Content = tmbArray[3].ToString();
            }
            if (txtBox5.Text != "" && btn5.Content != "")
                {
                    int fifthNmbr = Convert.ToInt32(btn5.Content);
                    int fifthNmbrIndx = int.Parse(txtBox5.Text) - 1;
                    tmbArray[fifthNmbrIndx] = fifthNmbr;
              
                txtBox5.IsEnabled = false;
                lblAfter1.Visibility = Visibility.Visible;
                lblAfter2.Visibility = Visibility.Visible;
                lblAfter3.Visibility = Visibility.Visible;
                lblAfter4.Visibility = Visibility.Visible;
                lblAfter5.Visibility = Visibility.Visible;
                lblTxt1.Visibility = Visibility.Visible; lblTxt1.Content = tmbArray[0].ToString();
                lblTxt2.Visibility = Visibility.Visible; lblTxt2.Content = tmbArray[1].ToString();
                lblTxt3.Visibility = Visibility.Visible; lblTxt3.Content = tmbArray[2].ToString();
                lblTxt4.Visibility = Visibility.Visible; lblTxt4.Content = tmbArray[3].ToString();
                lblTxt5.Visibility = Visibility.Visible; lblTxt5.Content = tmbArray[4].ToString();
            }
            if (txtBox6.Text != "" && btn6.Content != "")
                {
                    int sixthNmbr = Convert.ToInt32(btn6.Content);
                    int sixthNmbrIndx = int.Parse(txtBox6.Text) - 1;
                    tmbArray[sixthNmbrIndx] = sixthNmbr;

                txtBox6.IsEnabled = false;

                lblAfter1.Visibility = Visibility.Visible;
                lblAfter2.Visibility = Visibility.Visible;
                lblAfter3.Visibility = Visibility.Visible;
                lblAfter4.Visibility = Visibility.Visible;
                lblAfter5.Visibility = Visibility.Visible;
                lblAfter6.Visibility = Visibility.Visible;
                lblTxt1.Visibility = Visibility.Visible; lblTxt1.Content = tmbArray[0].ToString();
                lblTxt2.Visibility = Visibility.Visible; lblTxt2.Content = tmbArray[1].ToString();
                lblTxt3.Visibility = Visibility.Visible; lblTxt3.Content = tmbArray[2].ToString();
                lblTxt4.Visibility = Visibility.Visible; lblTxt4.Content = tmbArray[3].ToString();
                lblTxt5.Visibility = Visibility.Visible; lblTxt5.Content = tmbArray[4].ToString();
                lblTxt6.Visibility = Visibility.Visible; lblTxt6.Content = tmbArray[5].ToString();
            }
            if (txtBox7.Text != "" && btn7.Content != "")
                {
                    int seventhNmbr = Convert.ToInt32(btn7.Content);
                    int seventhNmbrIndx = int.Parse(txtBox7.Text) - 1;
                    tmbArray[seventhNmbrIndx] = seventhNmbr;

                txtBox7.IsEnabled = false;

                lblAfter1.Visibility = Visibility.Visible;
                lblAfter2.Visibility = Visibility.Visible;
                lblAfter3.Visibility = Visibility.Visible;
                lblAfter4.Visibility = Visibility.Visible;
                lblAfter5.Visibility = Visibility.Visible;
                lblAfter6.Visibility = Visibility.Visible;
                lblAfter7.Visibility = Visibility.Visible;
                lblTxt1.Visibility = Visibility.Visible; lblTxt1.Content = tmbArray[0].ToString();
                lblTxt2.Visibility = Visibility.Visible; lblTxt2.Content = tmbArray[1].ToString();
                lblTxt3.Visibility = Visibility.Visible; lblTxt3.Content = tmbArray[2].ToString();
                lblTxt4.Visibility = Visibility.Visible; lblTxt4.Content = tmbArray[3].ToString();
                lblTxt5.Visibility = Visibility.Visible; lblTxt5.Content = tmbArray[4].ToString();
                lblTxt6.Visibility = Visibility.Visible; lblTxt6.Content = tmbArray[5].ToString();
                lblTxt7.Visibility = Visibility.Visible; lblTxt7.Content = tmbArray[6].ToString();

            }

        }

        public void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            okBtn.IsEnabled = false;

            List<Routes> listCount = collection.AsQueryable().ToList<Routes>();

            int listaSorteds = 0;
            int listaSortedsF = 0;
            int maxIndex = tmbArray.Length;
            for (int i = 0; i < listCount.Count; i++)
            {
                if (listCount[i].isSorted == 1)
                {
                    listaSorteds++;
                }
                else
                {
                    listaSortedsF++;

                }
            }
            // Kiválasztott elemek lementése
            if (listaSorteds == 0)
            {
                List<Routes> lista = collection.AsQueryable().ToList<Routes>();
                List<Routes> tmpChoosenNList = new List<Routes>();

                int n = 0;
                while (n < maxIndex)
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (lista[i].number == tmbArray[n])
                        {
                            tmpChoosenNList.Add(lista[i]);
                            lista.Remove(lista[i]);
                        }
                    }
                    n++;
                }


                int j = 0;
                while (j < (tmpChoosenNList.Count))
                {
                    var update = Builders<Routes>.Update.Set("number", tmpChoosenNList[j].number).Set("isSorted", 1);
                    collection.UpdateOne(ev => ev._id == j, update);
                    j++;
                }
                int tm = tmpChoosenNList.Count;
                int km = 0;
                int tmMax = tmpChoosenNList.Count + lista.Count;
                while (tm < tmMax)
                {
                    var update = Builders<Routes>.Update.Set("number", lista[km].number).Set("isSorted", lista[km].isSorted);
                    collection.UpdateOne(ev => ev._id == tm, update);
                    tm++;
                    km++;
                }
            }
            // HA VAN 1-gyes és 0-ás
            else if (listaSorteds > 0 && listaSortedsF > 0)
            {

                List<Routes> lista = collection.AsQueryable().ToList<Routes>();
                List<Routes> tmpChoosenNList = new List<Routes>();
                List<Routes> listforUnchoosenSorteds = new List<Routes>();

                // Első n elem betöltése, és a listából kivétele, ez fog a listforunchoosen után menni egyből
                int n = 0;
                while (n < maxIndex)
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (lista[i].number == tmbArray[n])
                        {
                            tmpChoosenNList.Add(lista[i]);
                            lista.Remove(lista[i]);
                        }
                    }
                    n++;
                }


              

                // A nem kiválasztott már rendezett elemek kimentése
                int listSortd = 0;
                int listSortdF = 0;
                int nu = 0;
                while (nu < listaSorteds)
                {
                    for (int i=0 ; i < lista.Count; i++)
                    {
                        
                        if (lista[i].isSorted == 1)
                        {
                            i = 0;
                            listSortd++;
                            listforUnchoosenSorteds.Add(lista[i]);
                            lista.Remove(lista[i]);
                        }
                        else
                        {
                            listSortdF++;

                        }

                    }
                    nu++;
                }



                int numb = 0;

                if (lista.Count > 1)
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        while (numb < lista.Count - 1)
                        {
                            if (lista[numb]._id > lista[numb + 1]._id)
                            {
                                int tmp = lista[numb]._id;
                                lista[numb]._id = lista[numb + 1]._id;
                                lista[numb + 1]._id = tmp;
                            }
                            numb++;
                        }

                    }
                }


                int kb = 0;
                while (kb < listforUnchoosenSorteds.Count)
                {
                    var update = Builders<Routes>.Update.Set("number", listforUnchoosenSorteds[kb].number).Set("isSorted", 1);
                    collection.UpdateOne(ev => ev._id == kb, update);
                    
                    kb++;
                }

                int j = kb;
                int ka = 0;
                while (ka<tmpChoosenNList.Count)
                {
                    var update = Builders<Routes>.Update.Set("number", tmpChoosenNList[ka].number).Set("isSorted", 1);
                    collection.UpdateOne(ev => ev._id == j, update);
                    j++;
                    ka++;
                }

                int tm = j;
                int km = 0;
                int tmMax =  lista.Count;
                while (km < tmMax)
                {
                    var update = Builders<Routes>.Update.Set("number", lista[km].number).Set("isSorted", lista[km].isSorted);
                    collection.UpdateOne(ev => ev._id == tm, update);
                    tm++;
                    km++;
                }



            }
            else     // HA CSAK 1- GYES VAN
            {
                //List<Routes> updatedList = collection.AsQueryable().ToList<Routes>();
                List<Routes> listThirdOption = collection.AsQueryable().ToList<Routes>();
                List<Routes> choosenNumbers = new List<Routes>();

                List<Routes> choosenUpdate = new List<Routes>();

                int n = 0;
                while (n < maxIndex)
                {
                    
                    for (int i = 0; i < listThirdOption.Count; i++)
                    {

                        if (listThirdOption[i].number == tmbArray[n])
                        {
                            choosenNumbers.Add(listThirdOption[i]);
                            choosenUpdate.Add(listThirdOption[i]);
                            listThirdOption.Remove(listThirdOption[i]);
                        }

                    }
                    n++;
                }

                int[] tmpArray = new int[choosenUpdate.Count];
                int naj = 0;
                while (naj < tmpArray.Length)
                {
                    tmpArray[naj] = choosenNumbers[naj]._id;
                    naj++;
                }

                if (tmpArray.Length > 1)
                {
                    for (int i = 0; i < tmpArray.Length; i++)
                    {
                int numb = 0;
                        while (numb < tmpArray.Length - 1)
                        {
                            if (tmpArray[numb] > tmpArray[numb + 1])
                            {
                                int tmp = tmpArray[numb];
                                tmpArray[numb] = tmpArray[numb + 1];
                                tmpArray[numb + 1] = tmp;
                            }
                            numb++;
                        }

                    }
                }



                int nm = 0;
                while (nm < choosenNumbers.Count)
                {

                    var update = Builders<Routes>.Update.Set("number", choosenNumbers[nm].number).Set("isSorted", listThirdOption[nm].isSorted);
                    collection.UpdateOne(ev => ev._id == tmpArray[nm], update);

                    nm++;
                        
                    
                }

            }

            ReadAllDocuments();

        }

        private void BtnFirst_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button b = (Button)sender;
            DragDrop.DoDragDrop(b, b.Content, DragDropEffects.Move);
            indexIs();
            btnFirst.IsEnabled = false;
        }

        private void BtnSecond_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button b = (Button)sender;
            DragDrop.DoDragDrop(b, b.Content, DragDropEffects.Move);
            indexIs();
            btnSecond.IsEnabled = false;

        }

        private void BtnThird_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button b = (Button)sender;
            DragDrop.DoDragDrop(b, b.Content, DragDropEffects.Move);
            indexIs();
            btnThird.IsEnabled = false;
        }

        private void BtnFourth_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button b = (Button)sender;
            DragDrop.DoDragDrop(b, b.Content, DragDropEffects.Move);
            indexIs();
            btnFourth.IsEnabled = false;

        }

        private void BtnFifth_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button b = (Button)sender;
            DragDrop.DoDragDrop(b, b.Content, DragDropEffects.Move);
            indexIs();
            btnFifth.IsEnabled = false;

        }

        private void BtnSixth_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button b = (Button)sender;
            DragDrop.DoDragDrop(b, b.Content, DragDropEffects.Move);
            indexIs();
            btnSixth.IsEnabled = false;

        }

        private void BtnSeventh_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button b = (Button)sender;
            DragDrop.DoDragDrop(b, b.Content, DragDropEffects.Move);
            indexIs();
            btnSeventh.IsEnabled = false;

        }

        private void BckBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("For Help: You can sort numbers with Drag'n Drop. Just take an index with your mouse and drop under your choosen number.");
        }

        private void ResetSrts_Click(object sender, RoutedEventArgs e)
        {
            okBtn.IsEnabled = true;

            btnFirst.IsEnabled = true;
            txtBox1.IsEnabled = true;
            btnSecond.IsEnabled = true;
            txtBox2.IsEnabled = true;

            txtBox1.Text = "";
            txtBox2.Text = "";
            txtBox3.Text = "";
            txtBox4.Text = "";
            txtBox5.Text = "";
            txtBox6.Text = "";
            txtBox7.Text = "";


            switch (tmbArray.Length)
            {

                case 1:
                    lblTxt1.Visibility = Visibility.Hidden; lblTxt1.Content = "";
                    break;
                case 2:
                    lblTxt1.Visibility = Visibility.Hidden; lblTxt1.Content = "";
                    lblTxt2.Visibility = Visibility.Hidden; lblTxt2.Content = "";
                    break;
                case 3:
                    btnThird.IsEnabled = true;
                    txtBox3.IsEnabled = true;
                    lblTxt1.Visibility = Visibility.Hidden; lblTxt1.Content = "";
                    lblTxt2.Visibility = Visibility.Hidden; lblTxt2.Content = "";
                    lblTxt3.Visibility = Visibility.Hidden; lblTxt3.Content = "";

                    break;
                case 4:
                    btnThird.IsEnabled = true;
                    btnFourth.IsEnabled = true;
                    txtBox3.IsEnabled = true;
                    txtBox4.IsEnabled = true;
                    lblTxt1.Visibility = Visibility.Hidden; lblTxt1.Content = "";
                    lblTxt2.Visibility = Visibility.Hidden; lblTxt2.Content = "";
                    lblTxt3.Visibility = Visibility.Hidden; lblTxt3.Content = "";
                    lblTxt4.Visibility = Visibility.Hidden; lblTxt4.Content = "";


                    break;
                case 5:
                    btnThird.IsEnabled = true;
                    btnFourth.IsEnabled = true;
                    btnFifth.IsEnabled = true;
                    txtBox3.IsEnabled = true;
                    txtBox4.IsEnabled = true;
                    txtBox5.IsEnabled = true;
                    lblTxt1.Visibility = Visibility.Hidden; lblTxt1.Content = "";
                    lblTxt2.Visibility = Visibility.Hidden; lblTxt2.Content = "";
                    lblTxt3.Visibility = Visibility.Hidden; lblTxt3.Content = "";
                    lblTxt4.Visibility = Visibility.Hidden; lblTxt4.Content = "";
                    lblTxt5.Visibility = Visibility.Hidden; lblTxt5.Content = "";



                    break;
                case 6:
                    btnThird.IsEnabled = true;
                    btnFourth.IsEnabled = true;
                    btnFifth.IsEnabled = true;
                    btnSixth.IsEnabled = true;
                    txtBox3.IsEnabled = true;
                    txtBox4.IsEnabled = true;
                    txtBox5.IsEnabled = true;
                    txtBox6.IsEnabled = true;
                    lblTxt1.Visibility = Visibility.Hidden; lblTxt1.Content = "";
                    lblTxt2.Visibility = Visibility.Hidden; lblTxt2.Content = "";
                    lblTxt3.Visibility = Visibility.Hidden; lblTxt3.Content = "";
                    lblTxt4.Visibility = Visibility.Hidden; lblTxt4.Content = "";
                    lblTxt5.Visibility = Visibility.Hidden; lblTxt5.Content = "";
                    lblTxt6.Visibility = Visibility.Hidden; lblTxt6.Content = "";


                    break;
                case 7:
                    btnThird.IsEnabled = true;
                    btnFourth.IsEnabled = true;
                    btnFifth.IsEnabled = true;
                    btnSixth.IsEnabled = true;
                    btnSeventh.IsEnabled = true;
                    txtBox3.IsEnabled = true;
                    txtBox4.IsEnabled = true;
                    txtBox5.IsEnabled = true;
                    txtBox6.IsEnabled = true;
                    txtBox7.IsEnabled = true;
                    lblTxt1.Visibility = Visibility.Hidden; lblTxt1.Content = "";
                    lblTxt2.Visibility = Visibility.Hidden; lblTxt2.Content = "";
                    lblTxt3.Visibility = Visibility.Hidden; lblTxt3.Content = "";
                    lblTxt4.Visibility = Visibility.Hidden; lblTxt4.Content = "";
                    lblTxt5.Visibility = Visibility.Hidden; lblTxt5.Content = "";
                    lblTxt6.Visibility = Visibility.Hidden; lblTxt6.Content = "";
                    lblTxt7.Visibility = Visibility.Hidden; lblTxt7.Content = "";


                    break;
                default:
                    break;
            }
        }
    }
}
