using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;

namespace First
{
    public static class DB
    {

        private static SQLiteConnection DBConnect()
        {
            var filename = "ItemsSQLite.db3";
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(folder, filename);

            var connection = new SQLiteConnection(path);
            // connection.Trace = true;

            if (connection == null)
                throw new Exception("Nelze vytvořit připojení k dazabázi.");

            return connection;
        }

        /// <summary>
        /// What to do before start using program (only ones time, no for every run program)
        /// </summary>
        public static void PrepareDB()
        {
            using (var conn = DBConnect())
            {
                conn.CreateTable<Word>();

                // TODO: delete
                conn.DeleteAll<Word>();

                var data = conn.Table<Word>();
                if (data.Count() == 0)
                {
                    conn.Insert(new Word { WordCZ = "ahoj", WordEN = "hello", IsFraze = false, Weight = 2 });
                    conn.Insert(new Word { WordCZ = "mama", WordEN = "mum", IsFraze = false, Weight = 2 });
                    conn.Insert(new Word { WordCZ = "deda", WordEN = "grandpa", IsFraze = false, Weight = 2 });
                    conn.Insert(new Word { WordCZ = "vec", WordEN = "thing", IsFraze = false, Weight = 2 });

                    #region words

                    /*
                    r.Add(new Word(cz: "těšit se", en: "look forward to"));
                    r.Add(new Word(cz: "zapnout", en: "turn on"));
                    r.Add(new Word(cz: "vyzkoušet", en: "try on"));
                    r.Add(new Word(cz: "vzlétnout", en: "take off"));
                    r.Add(new Word(cz: "odhlásit se", en: "check out of"));
                    r.Add(new Word(cz: "odmítnout", en: "turn down"));
                    r.Add(new Word(cz: "vypnout", en: "turn off"));
                    r.Add(new Word(cz: "vrátit se (přinést zpět)", en: "bring back"));
                    r.Add(new Word(cz: "vrátit (na svoje místo)", en: "put back"));
                    r.Add(new Word(cz: "omdlít", en: "pass out"));
                    r.Add(new Word(cz: "zhlasit", en: "turn up"));
                    r.Add(new Word(cz: "otočit se", en: "turn around"));
                    r.Add(new Word(cz: "roztrhnout", en: "tear up"));
                    r.Add(new Word(cz: "jít s", en: "go with"));
                    r.Add(new Word(cz: "nasednout", en: "get on"));
                    r.Add(new Word(cz: "ztlumit", en: "turn down"));
                    r.Add(new Word(cz: "vloupat se", en: "break into"));
                    r.Add(new Word(cz: "jíst venku", en: "eat out"));
                    r.Add(new Word(cz: "odbavit, zaregistrovat", en: "check in to"));
                    r.Add(new Word(cz: "vyplnit", en: "fill in"));


                    // v2.0
                    r.Add(new Pair(cz: "souhlasit", en: "agree"));
                    r.Add(new Pair(cz: "vesnice", en: "village"));
                    r.Add(new Pair(cz: "předmětstí", en: "suburts"));
                    r.Add(new Pair(cz: "zařízený", en: "furnished"));
                    r.Add(new Pair(cz: "vynalézt", en: "invent"));
                    r.Add(new Pair(cz: "výhled", en: "view"));
                    r.Add(new Pair(cz: "nabízí", en: "offers"));
                    r.Add(new Pair(cz: "rozsáhlý,obrovský", en: "huge"));
                    r.Add(new Pair(cz: "venkov", en: "countriside"));
                    r.Add(new Pair(cz: "rušný", en: "busy"));
                    r.Add(new Pair(cz: "tichý", en: "quiet"));
                    r.Add(new Pair(cz: "pronajmout", en: "rent"));
                    r.Add(new Pair(cz: "blízko", en: "nearby"));
                    r.Add(new Pair(cz: "kromě", en: "beside"));
                    r.Add(new Pair(cz: "nájemníci", en: "tenants"));
                    r.Add(new Pair(cz: "laskvavý", en: "kind"));
                    r.Add(new Pair(cz: "vůbec ne", en: "all not at all"));
                    r.Add(new Pair(cz: "nezbytný", en: " nessesary"));
                    r.Add(new Pair(cz: "nabízet", en: "offers"));
                    r.Add(new Pair(cz: "téměř,skoro", en: "almost"));
                    r.Add(new Pair(cz: "útulný", en: "cosy"));
                    r.Add(new Pair(cz: "vzhled", en: "appearance"));
                    r.Add(new Pair(cz: "dokonce", en: "even"));
                    r.Add(new Pair(cz: "dospělý", en: "grown"));
                    r.Add(new Pair(cz: "potápět", en: "sing"));
                    r.Add(new Pair(cz: "chytrý", en: "clever"));
                    r.Add(new Pair(cz: "pilný", en: "hard-working"));
                    r.Add(new Pair(cz: "na příklad", en: "for example"));
                    r.Add(new Pair(cz: "příklad", en: "example"));
                    r.Add(new Pair(cz: "přežít", en: "survived"));
                    r.Add(new Pair(cz: "kulatý", en: "raund"));
                    r.Add(new Pair(cz: "rada", en: "advice"));
                    r.Add(new Pair(cz: "bouřka", en: "storm"));
                    r.Add(new Pair(cz: "vzal", en: "took off"));
                    r.Add(new Pair(cz: "kritický", en: "critical"));
                    r.Add(new Pair(cz: "smát se", en: "laugh"));
                    r.Add(new Pair(cz: "vstupní", en: "entrance"));
                    r.Add(new Pair(cz: "zájem", en: "interest"));
                    r.Add(new Pair(cz: "humor", en: "humour"));
                    r.Add(new Pair(cz: "čtvercový", en: "square"));
                    r.Add(new Pair(cz: "plynule", en: "fluently"));
                    r.Add(new Pair(cz: "plynulý", en: "fluent"));
                    r.Add(new Pair(cz: "ačkoliv", en: "although"));
                    r.Add(new Pair(cz: "poradit", en: "give advice"));
                    r.Add(new Pair(cz: "bohužel", en: "unfortunatley"));
                    r.Add(new Pair(cz: "pohledný", en: "good looking"));
                    r.Add(new Pair(cz: "dav", en: "crowd"));
                    r.Add(new Pair(cz: "budoucnost", en: "future"));
                    r.Add(new Pair(cz: "pilný", en: "hard"));
                    r.Add(new Pair(cz: "chování", en: "behaviour"));
                    r.Add(new Pair(cz: "bloudil,tápal", en: "boarded"));
                    r.Add(new Pair(cz: "poškození", en: "damage"));
                    r.Add(new Pair(cz: "navrhnout", en: "suggest"));
                    r.Add(new Pair(cz: "přístup", en: "access"));
                    r.Add(new Pair(cz: "zahrnuje", en: "include"));
                    r.Add(new Pair(cz: "dobrosrdečný", en: "kind-hearted"));
                    r.Add(new Pair(cz: "řetízek, řetěz", en: "chain"));
                    r.Add(new Pair(cz: "přistál", en: "landed"));
                    r.Add(new Pair(cz: "brzy", en: "soon"));
                    r.Add(new Pair(cz: "rozhodnout", en: "decide"));
                    r.Add(new Pair(cz: "chytit", en: "catch"));
                    r.Add(new Pair(cz: "hádat, hádanka", en: "guess"));
                    r.Add(new Pair(cz: "přežít", en: "survive"));
                    r.Add(new Pair(cz: "zrušit", en: "cancel"));
                    r.Add(new Pair(cz: "hádat se", en: "argue"));
                    r.Add(new Pair(cz: "popsat", en: "describe"));
                    r.Add(new Pair(cz: "dívat se na", en: " look at"));
                    r.Add(new Pair(cz: "hledat", en: "look for"));
                    r.Add(new Pair(cz: "těšit se", en: "look foreward to"));
                    r.Add(new Pair(cz: "ve zkutečnosti", en: "in fact"));
                    r.Add(new Pair(cz: "létat", en: "fly"));
                    r.Add(new Pair(cz: "potkali", en: "met"));
                    r.Add(new Pair(cz: "pár", en: "few"));
                    r.Add(new Pair(cz: "zkušenost", en: "metter of fact"));
                    r.Add(new Pair(cz: "poslední, alespoň", en: "at least"));
                    r.Add(new Pair(cz: "jenom 2 roky", en: "only 2 years"));
                    r.Add(new Pair(cz: "za ním", en: "behinde him"));
                    r.Add(new Pair(cz: "jsem si jistý", en: "I am sure"));
                    r.Add(new Pair(cz: "požaduje", en: "requires"));
                    r.Add(new Pair(cz: "cesta(letět)", en: "journey"));
                    r.Add(new Pair(cz: "cesta(jit)", en: "way"));
                    r.Add(new Pair(cz: "je to moc daleko", en: "It is to far"));
                    r.Add(new Pair(cz: "tentokrát", en: "this time"));
                    r.Add(new Pair(cz: "přijet,dorazit", en: "arrive"));
                    r.Add(new Pair(cz: "rozhodnout", en: "decide"));
                    r.Add(new Pair(cz: "spojit,sloučit", en: "marge"));
                    r.Add(new Pair(cz: "jednání", en: "negotiating"));
                    r.Add(new Pair(cz: "jednat", en: "negotiat"));
                    r.Add(new Pair(cz: "na konci roku", en: "at the end"));
                    r.Add(new Pair(cz: "konečně", en: "in the end"));
                    r.Add(new Pair(cz: "poprosit, požádat", en: "asked him"));
                    r.Add(new Pair(cz: "nastavit", en: "set up"));
                    r.Add(new Pair(cz: "obdržet", en: "receive"));
                    r.Add(new Pair(cz: "umožnit", en: "provite"));
                    r.Add(new Pair(cz: "proto", en: "therefore"));
                    r.Add(new Pair(cz: "zjistit", en: "find out"));
                    r.Add(new Pair(cz: "učeň", en: "learner"));
                    r.Add(new Pair(cz: "nabídnout", en: "offers"));
                    r.Add(new Pair(cz: "výzkum", en: "research"));
                    r.Add(new Pair(cz: "rozhovor", en: "interview"));
                    r.Add(new Pair(cz: "zloděj", en: "thief"));
                    r.Add(new Pair(cz: "schovaný", en: "hiding"));
                    r.Add(new Pair(cz: "vztoupil", en: "entered"));
                    r.Add(new Pair(cz: "zkušenost", en: "experience"));
                    r.Add(new Pair(cz: "doporučuje", en: "recommands"));
                    r.Add(new Pair(cz: "známý", en: "familiar"));
                    r.Add(new Pair(cz: "poznat", en: "recognise"));
                    r.Add(new Pair(cz: "uvedený", en: "mentioned"));
                    r.Add(new Pair(cz: "chráněný", en: "protected"));
                    r.Add(new Pair(cz: "autorské právo", en: "copy right"));
                    r.Add(new Pair(cz: "odhalovat", en: "discover"));
                    r.Add(new Pair(cz: "inzerující, reklamní", en: "advertising"));
                    r.Add(new Pair(cz: "inzerát, reklama", en: "advertisiment"));
                    r.Add(new Pair(cz: "přelidněný", en: "crowded"));
                    r.Add(new Pair(cz: "v porovnání", en: " compared to"));
                    r.Add(new Pair(cz: "porovnaný", en: "compared"));
                    r.Add(new Pair(cz: "úchvatný", en: "impresive"));
                    r.Add(new Pair(cz: "poskytuje", en: "provides"));
                    r.Add(new Pair(cz: "dočasné", en: "temporery tatoo"));
                    r.Add(new Pair(cz: "mohl by", en: "might lose"));
                    r.Add(new Pair(cz: "uspokojuje", en: "satisfies"));
                    r.Add(new Pair(cz: "něco", en: "something"));
                    r.Add(new Pair(cz: "cokoli", en: "anything"));
                    r.Add(new Pair(cz: "nic", en: "nothing"));
                    r.Add(new Pair(cz: "žádný", en: "none"));
                    r.Add(new Pair(cz: "žádný z něčeho", en: "none of"));
                    r.Add(new Pair(cz: "přijal", en: "received"));
                    r.Add(new Pair(cz: "reagoval, odpověděl", en: "responded"));
                    r.Add(new Pair(cz: "temný", en: "gloomy"));
                    r.Add(new Pair(cz: "drží", en: "holds"));
                    r.Add(new Pair(cz: "vrátit se", en: "return"));
                    r.Add(new Pair(cz: "opatrný", en: "careful"));
                    r.Add(new Pair(cz: "vřelý", en: "warm"));
                    r.Add(new Pair(cz: "znamenal", en: "meant"));
                    r.Add(new Pair(cz: "překvapení", en: "surprise"));
                    r.Add(new Pair(cz: "napínavý", en: "exciting"));
                    r.Add(new Pair(cz: "nedávný", en: "recent"));
                    r.Add(new Pair(cz: "starosti, znepokojuje", en: "worried"));
                    r.Add(new Pair(cz: "podrážděný", en: "excited"));
                    r.Add(new Pair(cz: "potěšený, spokojený", en: "pleased"));
                    r.Add(new Pair(cz: "překvapený", en: "surprised"));
                    r.Add(new Pair(cz: "každý", en: "each"));
                    r.Add(new Pair(cz: "platný", en: "valid"));
                    r.Add(new Pair(cz: "během dne", en: "during the day"));
                    r.Add(new Pair(cz: "železniční zastávka", en: "reilway station"));
                    r.Add(new Pair(cz: "odjezd", en: "departure"));
                    r.Add(new Pair(cz: "poškozený", en: "harmed"));
                    r.Add(new Pair(cz: "sloupek, pošta", en: " post"));
                    r.Add(new Pair(cz: "roznážka, doručení", en: "delivery"));
                    r.Add(new Pair(cz: "očekávat", en: "expect to"));
                    r.Add(new Pair(cz: "požadovaný", en: "requested"));
                    r.Add(new Pair(cz: "z větší části (hlavně)", en: " mostly"));
                    r.Add(new Pair(cz: "odejít", en: "leave"));
                    r.Add(new Pair(cz: "vynalézavý", en: "invented"));
                    r.Add(new Pair(cz: "účel", en: "purpose"));
                    */

                    #endregion words
                }
            }
        }

        /// <summary>
        /// Get all words duplicated by their weight
        /// </summary>
        /// <returns></returns>
        public static List<Word> GetAll()
        {
            var allWithWeight = new List<Word>();
            using (var conn = DBConnect())
            {
                var all = conn.Table<Word>();
                foreach(var item in all)
                {
                    for (int a = 0; a <= item.Weight; a++)
                        allWithWeight.Add(item);
                }
            }
            return allWithWeight;
        }

        /// <summary>
        /// Update one Word (by primary key - Id)
        /// </summary>
        /// <param name="item"></param>
        public static void Update(Word item)
        {
            using (var conn = DBConnect())
            {
                conn.Update(item);
            }
        }
    }
}
