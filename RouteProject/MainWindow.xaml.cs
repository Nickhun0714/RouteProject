using MongoDB.Bson;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RouteProject
{
 
    // GitHub repo test

    public partial class MainWindow : Window
    {
        public static int abcda = 1;

        static MongoClient client = new MongoClient();
        // TmpRoutes (use projectLabRoutes ; db.routes )
        static IMongoDatabase db = client.GetDatabase("projectLabRoutes");
        static IMongoCollection<Routes> collection = db.GetCollection<Routes>("routes");
        static int listCountUp;

        // OriginalRoutes (use ProjectLabRoutesOrigin ; db.routesOrigin )
        static IMongoDatabase dbOrigin = client.GetDatabase("ProjectLabRoutesOrigin");
        static IMongoCollection<RoutesOriginal> collectionOrigin = dbOrigin.GetCollection<RoutesOriginal>("routesOrigin");


        public void ReadAllDocuments()
        {
            List<Routes> list = collection.AsQueryable().ToList<Routes>();
            Routes r;

            // TO-DO lekezelni, ha üres az adatbázis -----> do while ciklusban a tmptry listát törölni kéne időközönként!
            // UP-DO elvileg megoldva, a lista nem ürült ki generálás után és túlcsordult
            if (list.Count() == 0)
            {
                collection = db.GetCollection<Routes>("routes");
                r = new Routes(5, 5, 5);
                collection.InsertOne(r);


                list = collection.AsQueryable().ToList<Routes>();

            }

            dtGrd.ItemsSource = list;
            r = (Routes)dtGrd.Items.GetItemAt(0);
            listCountUp = list.Count();

        }

        public void ReadOriginAllDocuments()
        {
            List<RoutesOriginal> listOrigin = collectionOrigin.AsQueryable().ToList<RoutesOriginal>();
            RoutesOriginal r;
            if (listOrigin.Count() == 0)
            {
                collectionOrigin = db.GetCollection<RoutesOriginal>("routesOrigin");
                r = new RoutesOriginal(5, 5);
                collectionOrigin.InsertOne(r);


                listOrigin = collectionOrigin.AsQueryable().ToList<RoutesOriginal>();

            }

            dtGrdOrigin.ItemsSource = listOrigin;
             r = (RoutesOriginal)dtGrdOrigin.Items.GetItemAt(0);
        }

        public MainWindow()
        {
            InitializeComponent();
            ReadAllDocuments();
            ReadOriginAllDocuments();
        }


        static public int _counter = collection.AsQueryable().Count();
        static public Random rnd = new Random();
        static public List<int> tryRepeat = new List<int>();

        private void GnrtNmbr_Click(object sender, RoutedEventArgs e)
        {
            db.DropCollection("routes");
            dbOrigin.DropCollection("routesOrigin");

            tryRepeat = new List<int>();

            System.Threading.Thread.Sleep(1000);
            // 15 és 75 között generál egy darabszámot
            int numbers = rnd.Next(15, 75);
            int nmb;


            collection = db.GetCollection<Routes>("routes");

            collectionOrigin = dbOrigin.GetCollection<RoutesOriginal>("routesOrigin");

            for (int _counter = 0; _counter < numbers; _counter++)
            {
                do
                {
                    // 1 és 300 között legenerálja a számokat
                    nmb = rnd.Next(1, 300);
                } while (tryRepeat.Contains(nmb));
                tryRepeat.Add(nmb);

                Routes r = new Routes(_counter, nmb, 0);
                RoutesOriginal b = new RoutesOriginal(r._id, nmb);
                collection.InsertOne(r);
                collectionOrigin.InsertOne(b);

            }
            ReadAllDocuments();
            ReadOriginAllDocuments();

        }




        private void NsrtBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);

            int rndInsNumb = rnd.Next(1, 5);
            List<Routes> listTmp = collection.AsQueryable().ToList<Routes>();

            int isTrueCount = 0;
            int isFalseCount = 0;
            for (int i = 0; i < listTmp.Count; i++)
            {
                if (listTmp[i].isSorted == 1)
                {
                    isTrueCount++;
                }
                else
                {
                    isFalseCount++;
                }
            }

            if (isTrueCount == 0)
            {
                int h = 0;
                while (h < rndInsNumb)
                {
                    List<Routes> list = collection.AsQueryable().ToList<Routes>();
                    int insert = 1;
                    int nmb;
                    Routes r;
                    for (int i = 0; i < insert; i++)
                    {
                        int rndNumb = rnd.Next(0, list.Count());
                        int rndInd = rndNumb;
                        do
                        {
                            nmb = rnd.Next(1, 200);
                        } while (tryRepeat.Contains(nmb));
                        tryRepeat.Add(nmb);




                        List<Routes> tmpList = new List<Routes>();
                        while (rndInd < listCountUp)
                        {

                            tmpList.Add(list[rndInd]);
                            rndInd++;
                        }

                        r = new Routes(listCountUp, 0, 0);
                        collection.InsertOne(r);

                        var updateDef = Builders<Routes>.Update.Set("number", nmb).Set("isSorted", 0);
                        collection.UpdateOne(ev => ev._id == rndNumb, updateDef);

                        ReadAllDocuments();

                        int j = 0;
                        while (j < tmpList.Count())
                        {
                            rndNumb++;
                            var updateDefAg = Builders<Routes>.Update.Set("number", tmpList[j].number).Set("isSorted", tmpList[j].isSorted);
                            j++;
                            collection.UpdateOne(ev => ev._id == rndNumb, updateDefAg);
                            ReadAllDocuments();

                        }

                        ReadAllDocuments();

                    }


                    h++;
                }
            }
            else if (isTrueCount > 0 && isFalseCount > 0)
            {
                List<Routes> listOrigin = collection.AsQueryable().ToList<Routes>();
                List<Routes> listForTmp = collection.AsQueryable().ToList<Routes>();
                List<Routes> tryList = collection.AsQueryable().ToList<Routes>();
                List<Routes> listForOnes = new List<Routes>();
                //1-esek lementése
                int n = 0;
                Routes r;
                while (n < isTrueCount)
                {
                    for (int i = 0; i < listOrigin.Count; i++)
                    {
                        if (listOrigin[i].isSorted == 1)
                        {
                            listForOnes.Add(listOrigin[i]);
                            listOrigin.Remove(listOrigin[i]);
                        }
                    }
                    n++;
                }
                int minIndex = listForOnes.Count;
                int maxIndex = listOrigin.Count;



                int h = 0;
                // csak 1-et lehet beszúrni, valami gázos vele
                while (h < 1)
                {
                    //List<Routes> list = collection.AsQueryable().ToList<Routes>();
                    int insert = 1;
                    int nmb;

                    for (int i = 0; i < insert; i++)
                    {
                        int rndNumb = rnd.Next(minIndex, listForTmp.Count());
                        int rndInd = rndNumb;
                        do
                        {
                            nmb = rnd.Next(1, 200);
                        } while (tryRepeat.Contains(nmb));
                        tryRepeat.Add(nmb);




                        List<Routes> tmpList = new List<Routes>();

                        while (rndInd < listCountUp)
                        {

                            tmpList.Add(tryList[rndInd]);
                            rndInd++;
                        }

                        r = new Routes(listCountUp, 0, 0);
                        collection.InsertOne(r);

                        var updateDef = Builders<Routes>.Update.Set("number", nmb).Set("isSorted", 0);
                        collection.UpdateOne(ev => ev._id == rndNumb, updateDef);

                        ReadAllDocuments();

                        int j = 0;
                        while (j < tmpList.Count())
                        {
                            rndNumb++;
                            var updateDefAg = Builders<Routes>.Update.Set("number", tmpList[j].number).Set("isSorted", tmpList[j].isSorted);
                            j++;
                            collection.UpdateOne(ev => ev._id == rndNumb, updateDefAg);
                            ReadAllDocuments();

                        }

                        ReadAllDocuments();

                    }


                    h++;
                }



            }
            else
            {
                List<Routes> listOrigin = collection.AsQueryable().ToList<Routes>();
                List<Routes> listForTmp = collection.AsQueryable().ToList<Routes>();
                List<Routes> tryList = collection.AsQueryable().ToList<Routes>();
                List<Routes> listForOnes = new List<Routes>();
                //1-esek lementése
                int n = 0;
                Routes r;


                int h = 0;
                while (h < 1) // rndInsNumb)
                {
                    //List<Routes> list = collection.AsQueryable().ToList<Routes>();
                    int insert = 1;
                    int nmb;

                    for (int i = 0; i < insert; i++)
                    {
                        //int rndNumb = rnd.Next(minIndex, listForTmp.Count());
                        //int rndInd = rndNumb;
                        do
                        {
                            nmb = rnd.Next(1, 200);
                        } while (tryRepeat.Contains(nmb));
                        tryRepeat.Add(nmb);


                        r = new Routes(listCountUp, nmb, 0);
                        collection.InsertOne(r);

                        ReadAllDocuments();
                    }


                    h++;
                }



            }
        }
    




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SortingRoutes sR = new SortingRoutes();
            sR.Show();
            this.Close();
        }
    }
}
