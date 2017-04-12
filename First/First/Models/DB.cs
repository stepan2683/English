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
        /// Get all words duplicated by their weight
        /// </summary>
        /// <returns></returns>
        public static List<Word> GetAllWithWeight()
        {
            List<Word> allWithWeight = new List<Word>();
            using (var conn = DBConnect())
            {
                foreach (var item in conn.Table<Word>())
                {
                    for (int a = 0; a < item.Weight; a++)
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

        public static void Insert(Word item)
        {
            using (var conn = DBConnect())
            {
                conn.Insert(item);
            }
        }

        public static bool Exists(Word item)
        {
            using (var conn = DBConnect())
            {
                var r = conn.Table<Word>();
                return r.Where(a => a.WordCZ == item.WordCZ).Count() > 0;
            }
        }

        public static void InsertIfNotExists(Word item, int weight = 3, bool isFraze = false)
        {
            item.Weight = 3;
            item.IsFraze = isFraze;
            if (!Exists(item))
                Insert(item);
        }

        public static void UpdateOneByCZWord(Word item, int weight)
        {
            using (var conn = DBConnect())
            {
                var forUpdate = conn.Table<Word>().Where(a => a.WordCZ == item.WordCZ).First();
                forUpdate.Weight = weight;
                Update(forUpdate);
            }    
        }

        /// <summary>
        /// What to do before start using program (only ones time, no for every run program)
        /// </summary>
        public static void PrepareDB()
        {
            using (var conn = DBConnect())
            {
                conn.CreateTable<Word>();

                #region words
                
                InsertIfNotExists(new Word { WordCZ = "těšit se", WordEN = "look forward to" });
                InsertIfNotExists(new Word { WordCZ = "zapnout", WordEN = "turn on" });
                InsertIfNotExists(new Word { WordCZ = "vyzkoušet", WordEN = "try on" });
                InsertIfNotExists(new Word { WordCZ = "vzlétnout", WordEN = "take off" });
                InsertIfNotExists(new Word { WordCZ = "odhlásit se", WordEN = "check out of" });
                InsertIfNotExists(new Word { WordCZ = "odmítnout", WordEN = "turn down" });
                InsertIfNotExists(new Word { WordCZ = "vypnout", WordEN = "turn off" });
                InsertIfNotExists(new Word { WordCZ = "vrátit se (přinést zpět)", WordEN = "bring back" });
                InsertIfNotExists(new Word { WordCZ = "vrátit (na svoje místo)", WordEN = "put back" });
                InsertIfNotExists(new Word { WordCZ = "omdlít", WordEN = "pass out" });
                InsertIfNotExists(new Word { WordCZ = "zhlasit", WordEN = "turn up" });
                InsertIfNotExists(new Word { WordCZ = "otočit se", WordEN = "turn around" });
                InsertIfNotExists(new Word { WordCZ = "roztrhnout", WordEN = "tear up" });
                InsertIfNotExists(new Word { WordCZ = "jít s", WordEN = "go with" });
                InsertIfNotExists(new Word { WordCZ = "nasednout", WordEN = "get on" });
                InsertIfNotExists(new Word { WordCZ = "ztlumit", WordEN = "turn down" });
                InsertIfNotExists(new Word { WordCZ = "vloupat se", WordEN = "break into" });
                InsertIfNotExists(new Word { WordCZ = "jíst venku", WordEN = "eat out" });
                InsertIfNotExists(new Word { WordCZ = "odbavit, zaregistrovat", WordEN = "check in to" });
                InsertIfNotExists(new Word { WordCZ = "vyplnit", WordEN = "fill in" });


                // v2.0
                InsertIfNotExists(new Word { WordCZ = "souhlasit", WordEN = "agree" });
                InsertIfNotExists(new Word { WordCZ = "vesnice", WordEN = "village" });
                InsertIfNotExists(new Word { WordCZ = "předmětstí", WordEN = "suburts" });
                InsertIfNotExists(new Word { WordCZ = "zařízený", WordEN = "furnished" });
                InsertIfNotExists(new Word { WordCZ = "vynalézt", WordEN = "invent" });
                InsertIfNotExists(new Word { WordCZ = "výhled", WordEN = "view" });
                InsertIfNotExists(new Word { WordCZ = "nabízí", WordEN = "offers" });
                InsertIfNotExists(new Word { WordCZ = "rozsáhlý,obrovský", WordEN = "huge" });
                InsertIfNotExists(new Word { WordCZ = "venkov", WordEN = "countriside" });
                InsertIfNotExists(new Word { WordCZ = "rušný", WordEN = "busy" });
                InsertIfNotExists(new Word { WordCZ = "tichý", WordEN = "quiet" });
                InsertIfNotExists(new Word { WordCZ = "pronajmout", WordEN = "rent" });
                InsertIfNotExists(new Word { WordCZ = "blízko", WordEN = "nearby" });
                InsertIfNotExists(new Word { WordCZ = "kromě", WordEN = "beside" });
                InsertIfNotExists(new Word { WordCZ = "nájemníci", WordEN = "tenants" });
                InsertIfNotExists(new Word { WordCZ = "laskvavý", WordEN = "kind" });
                InsertIfNotExists(new Word { WordCZ = "vůbec ne", WordEN = "all not at all" });
                InsertIfNotExists(new Word { WordCZ = "nezbytný", WordEN = " nessesary" });
                InsertIfNotExists(new Word { WordCZ = "nabízet", WordEN = "offers" });
                InsertIfNotExists(new Word { WordCZ = "téměř,skoro", WordEN = "almost" });
                InsertIfNotExists(new Word { WordCZ = "útulný", WordEN = "cosy" });
                InsertIfNotExists(new Word { WordCZ = "vzhled", WordEN = "appearance" });
                InsertIfNotExists(new Word { WordCZ = "dokonce", WordEN = "even" });
                InsertIfNotExists(new Word { WordCZ = "dospělý", WordEN = "grown" });
                InsertIfNotExists(new Word { WordCZ = "potápět", WordEN = "sing" });
                InsertIfNotExists(new Word { WordCZ = "chytrý", WordEN = "clever" });
                InsertIfNotExists(new Word { WordCZ = "pilný", WordEN = "hard-working" });
                InsertIfNotExists(new Word { WordCZ = "na příklad", WordEN = "for example" });
                InsertIfNotExists(new Word { WordCZ = "příklad", WordEN = "example" });
                InsertIfNotExists(new Word { WordCZ = "přežít", WordEN = "survived" });
                InsertIfNotExists(new Word { WordCZ = "kulatý", WordEN = "raund" });
                InsertIfNotExists(new Word { WordCZ = "rada", WordEN = "advice" });
                InsertIfNotExists(new Word { WordCZ = "bouřka", WordEN = "storm" });
                InsertIfNotExists(new Word { WordCZ = "vzal", WordEN = "took off" });
                InsertIfNotExists(new Word { WordCZ = "kritický", WordEN = "critical" });
                InsertIfNotExists(new Word { WordCZ = "smát se", WordEN = "laugh" });
                InsertIfNotExists(new Word { WordCZ = "vstupní", WordEN = "entrance" });
                InsertIfNotExists(new Word { WordCZ = "zájem", WordEN = "interest" });
                InsertIfNotExists(new Word { WordCZ = "humor", WordEN = "humour" });
                InsertIfNotExists(new Word { WordCZ = "čtvercový", WordEN = "square" });
                InsertIfNotExists(new Word { WordCZ = "plynule", WordEN = "fluently" });
                InsertIfNotExists(new Word { WordCZ = "plynulý", WordEN = "fluent" });
                InsertIfNotExists(new Word { WordCZ = "ačkoliv", WordEN = "although" });
                InsertIfNotExists(new Word { WordCZ = "poradit", WordEN = "give advice" });
                InsertIfNotExists(new Word { WordCZ = "bohužel", WordEN = "unfortunatley" });
                InsertIfNotExists(new Word { WordCZ = "pohledný", WordEN = "good looking" });
                InsertIfNotExists(new Word { WordCZ = "dav", WordEN = "crowd" });
                InsertIfNotExists(new Word { WordCZ = "budoucnost", WordEN = "future" });
                InsertIfNotExists(new Word { WordCZ = "pilný", WordEN = "hard" });
                InsertIfNotExists(new Word { WordCZ = "chování", WordEN = "behaviour" });
                InsertIfNotExists(new Word { WordCZ = "bloudil,tápal", WordEN = "boarded" });
                InsertIfNotExists(new Word { WordCZ = "poškození", WordEN = "damage" });
                InsertIfNotExists(new Word { WordCZ = "navrhnout", WordEN = "suggest" });
                InsertIfNotExists(new Word { WordCZ = "přístup", WordEN = "access" });
                InsertIfNotExists(new Word { WordCZ = "zahrnuje", WordEN = "include" });
                InsertIfNotExists(new Word { WordCZ = "dobrosrdečný", WordEN = "kind-hearted" });
                InsertIfNotExists(new Word { WordCZ = "řetízek, řetěz", WordEN = "chain" });
                InsertIfNotExists(new Word { WordCZ = "přistál", WordEN = "landed" });
                InsertIfNotExists(new Word { WordCZ = "brzy", WordEN = "soon" });
                InsertIfNotExists(new Word { WordCZ = "rozhodnout", WordEN = "decide" });
                InsertIfNotExists(new Word { WordCZ = "chytit", WordEN = "catch" });
                InsertIfNotExists(new Word { WordCZ = "hádat, hádanka", WordEN = "guess" });
                InsertIfNotExists(new Word { WordCZ = "přežít", WordEN = "survive" });
                InsertIfNotExists(new Word { WordCZ = "zrušit", WordEN = "cancel" });
                InsertIfNotExists(new Word { WordCZ = "hádat se", WordEN = "argue" });
                InsertIfNotExists(new Word { WordCZ = "popsat", WordEN = "describe" });
                InsertIfNotExists(new Word { WordCZ = "dívat se na", WordEN = " look at" });
                InsertIfNotExists(new Word { WordCZ = "hledat", WordEN = "look for" });
                InsertIfNotExists(new Word { WordCZ = "těšit se", WordEN = "look foreward to" });
                InsertIfNotExists(new Word { WordCZ = "ve zkutečnosti", WordEN = "in fact" });
                InsertIfNotExists(new Word { WordCZ = "létat", WordEN = "fly" });
                InsertIfNotExists(new Word { WordCZ = "potkali", WordEN = "met" });
                InsertIfNotExists(new Word { WordCZ = "pár", WordEN = "few" });
                InsertIfNotExists(new Word { WordCZ = "zkušenost", WordEN = "metter of fact" });
                InsertIfNotExists(new Word { WordCZ = "poslední, alespoň", WordEN = "at least" });
                InsertIfNotExists(new Word { WordCZ = "jenom 2 roky", WordEN = "only 2 years" });
                InsertIfNotExists(new Word { WordCZ = "za ním", WordEN = "behinde him" });
                InsertIfNotExists(new Word { WordCZ = "jsem si jistý", WordEN = "I am sure" });
                InsertIfNotExists(new Word { WordCZ = "požaduje", WordEN = "requires" });
                InsertIfNotExists(new Word { WordCZ = "cesta(letět)", WordEN = "journey" });
                InsertIfNotExists(new Word { WordCZ = "cesta(jit)", WordEN = "way" });
                InsertIfNotExists(new Word { WordCZ = "je to moc daleko", WordEN = "It is to far" });
                InsertIfNotExists(new Word { WordCZ = "tentokrát", WordEN = "this time" });
                InsertIfNotExists(new Word { WordCZ = "přijet,dorazit", WordEN = "arrive" });
                InsertIfNotExists(new Word { WordCZ = "rozhodnout", WordEN = "decide" });
                InsertIfNotExists(new Word { WordCZ = "spojit,sloučit", WordEN = "marge" });
                InsertIfNotExists(new Word { WordCZ = "jednání", WordEN = "negotiating" });
                InsertIfNotExists(new Word { WordCZ = "jednat", WordEN = "negotiat" });
                InsertIfNotExists(new Word { WordCZ = "na konci roku", WordEN = "at the end" });
                InsertIfNotExists(new Word { WordCZ = "konečně", WordEN = "in the end" });
                InsertIfNotExists(new Word { WordCZ = "poprosit, požádat", WordEN = "asked him" });
                InsertIfNotExists(new Word { WordCZ = "nastavit", WordEN = "set up" });
                InsertIfNotExists(new Word { WordCZ = "obdržet", WordEN = "receive" });
                InsertIfNotExists(new Word { WordCZ = "umožnit", WordEN = "provite" });
                InsertIfNotExists(new Word { WordCZ = "proto", WordEN = "therefore" });
                InsertIfNotExists(new Word { WordCZ = "zjistit", WordEN = "find out" });
                InsertIfNotExists(new Word { WordCZ = "učeň", WordEN = "learner" });
                InsertIfNotExists(new Word { WordCZ = "nabídnout", WordEN = "offers" });
                InsertIfNotExists(new Word { WordCZ = "výzkum", WordEN = "research" });
                InsertIfNotExists(new Word { WordCZ = "rozhovor", WordEN = "interview" });
                InsertIfNotExists(new Word { WordCZ = "zloděj", WordEN = "thief" });
                InsertIfNotExists(new Word { WordCZ = "schovaný", WordEN = "hiding" });
                InsertIfNotExists(new Word { WordCZ = "vztoupil", WordEN = "entered" });
                InsertIfNotExists(new Word { WordCZ = "zkušenost", WordEN = "experience" });
                InsertIfNotExists(new Word { WordCZ = "doporučuje", WordEN = "recommands" });
                InsertIfNotExists(new Word { WordCZ = "známý", WordEN = "familiar" });
                InsertIfNotExists(new Word { WordCZ = "poznat", WordEN = "recognise" });
                InsertIfNotExists(new Word { WordCZ = "uvedený", WordEN = "mentioned" });
                InsertIfNotExists(new Word { WordCZ = "chráněný", WordEN = "protected" });
                InsertIfNotExists(new Word { WordCZ = "autorské právo", WordEN = "copy right" });
                InsertIfNotExists(new Word { WordCZ = "odhalovat", WordEN = "discover" });
                InsertIfNotExists(new Word { WordCZ = "inzerující, reklamní", WordEN = "advertising" });
                InsertIfNotExists(new Word { WordCZ = "inzerát, reklama", WordEN = "advertisiment" });
                InsertIfNotExists(new Word { WordCZ = "přelidněný", WordEN = "crowded" });
                InsertIfNotExists(new Word { WordCZ = "v porovnání", WordEN = " compared to" });
                InsertIfNotExists(new Word { WordCZ = "porovnaný", WordEN = "compared" });
                InsertIfNotExists(new Word { WordCZ = "úchvatný", WordEN = "impresive" });
                InsertIfNotExists(new Word { WordCZ = "poskytuje", WordEN = "provides" });
                InsertIfNotExists(new Word { WordCZ = "dočasné", WordEN = "temporery tatoo" });
                InsertIfNotExists(new Word { WordCZ = "mohl by", WordEN = "might lose" });
                InsertIfNotExists(new Word { WordCZ = "uspokojuje", WordEN = "satisfies" });
                InsertIfNotExists(new Word { WordCZ = "něco", WordEN = "something" });
                InsertIfNotExists(new Word { WordCZ = "cokoli", WordEN = "anything" });
                InsertIfNotExists(new Word { WordCZ = "nic", WordEN = "nothing" });
                InsertIfNotExists(new Word { WordCZ = "žádný", WordEN = "none" });
                InsertIfNotExists(new Word { WordCZ = "žádný z něčeho", WordEN = "none of" });
                InsertIfNotExists(new Word { WordCZ = "přijal", WordEN = "received" });
                InsertIfNotExists(new Word { WordCZ = "reagoval, odpověděl", WordEN = "responded" });
                InsertIfNotExists(new Word { WordCZ = "temný", WordEN = "gloomy" });
                InsertIfNotExists(new Word { WordCZ = "drží", WordEN = "holds" });
                InsertIfNotExists(new Word { WordCZ = "vrátit se", WordEN = "return" });
                InsertIfNotExists(new Word { WordCZ = "opatrný", WordEN = "careful" });
                InsertIfNotExists(new Word { WordCZ = "vřelý", WordEN = "warm" });
                InsertIfNotExists(new Word { WordCZ = "znamenal", WordEN = "meant" });
                InsertIfNotExists(new Word { WordCZ = "překvapení", WordEN = "surprise" });
                InsertIfNotExists(new Word { WordCZ = "napínavý", WordEN = "exciting" });
                InsertIfNotExists(new Word { WordCZ = "nedávný", WordEN = "recent" });
                InsertIfNotExists(new Word { WordCZ = "starosti, znepokojuje", WordEN = "worried" });
                InsertIfNotExists(new Word { WordCZ = "podrážděný", WordEN = "excited" });
                InsertIfNotExists(new Word { WordCZ = "potěšený, spokojený", WordEN = "pleased" });
                InsertIfNotExists(new Word { WordCZ = "překvapený", WordEN = "surprised" });
                InsertIfNotExists(new Word { WordCZ = "každý", WordEN = "each" });
                InsertIfNotExists(new Word { WordCZ = "platný", WordEN = "valid" });
                InsertIfNotExists(new Word { WordCZ = "během dne", WordEN = "during the day" });
                InsertIfNotExists(new Word { WordCZ = "železniční zastávka", WordEN = "reilway station" });
                InsertIfNotExists(new Word { WordCZ = "odjezd", WordEN = "departure" });
                InsertIfNotExists(new Word { WordCZ = "poškozený", WordEN = "harmed" });
                InsertIfNotExists(new Word { WordCZ = "sloupek, pošta", WordEN = " post" });
                InsertIfNotExists(new Word { WordCZ = "roznážka, doručení", WordEN = "delivery" });
                InsertIfNotExists(new Word { WordCZ = "očekávat", WordEN = "expect to" });
                InsertIfNotExists(new Word { WordCZ = "požadovaný", WordEN = "requested" });
                InsertIfNotExists(new Word { WordCZ = "z větší části (hlavně)", WordEN = " mostly" });
                InsertIfNotExists(new Word { WordCZ = "odejít", WordEN = "leave" });
                InsertIfNotExists(new Word { WordCZ = "vynalézavý", WordEN = "invented" });
                InsertIfNotExists(new Word { WordCZ = "účel", WordEN = "purpose" });

                // v3.0
                InsertIfNotExists(new Word { WordCZ = "postarší, starší", WordEN = "elderly " });
                InsertIfNotExists(new Word { WordCZ = "důchod", WordEN = "retire" });
                InsertIfNotExists(new Word { WordCZ = "zaměstnavatel", WordEN = "employer" });
                InsertIfNotExists(new Word { WordCZ = "plány", WordEN = "plans" });
                InsertIfNotExists(new Word { WordCZ = "výplatní šek", WordEN = "pay cheque" });
                InsertIfNotExists(new Word { WordCZ = "dodavatel", WordEN = "contractor" });
                InsertIfNotExists(new Word { WordCZ = "laskavost", WordEN = "favour" });
                InsertIfNotExists(new Word { WordCZ = "levné", WordEN = "cheap" });
                InsertIfNotExists(new Word { WordCZ = "nekvalitní", WordEN = "low-class" });
                InsertIfNotExists(new Word { WordCZ = "nešťastný způsob", WordEN = "unfortunate way" });
                InsertIfNotExists(new Word { WordCZ = "podával", WordEN = "handed" });
                InsertIfNotExists(new Word { WordCZ = "ostuda, škoda", WordEN = "shame" });
                InsertIfNotExists(new Word { WordCZ = "kdyby", WordEN = "If" });
                InsertIfNotExists(new Word { WordCZ = "s námi", WordEN = "with us" });
                InsertIfNotExists(new Word { WordCZ = "méně", WordEN = "less" });
                InsertIfNotExists(new Word { WordCZ = "poznat, zjistit", WordEN = "realise" });
                InsertIfNotExists(new Word { WordCZ = "muset", WordEN = "have to" });
                InsertIfNotExists(new Word { WordCZ = "přístup", WordEN = "attitude" });
                InsertIfNotExists(new Word { WordCZ = "moudře", WordEN = "wisely" });
                InsertIfNotExists(new Word { WordCZ = "práce", WordEN = "work" });
                InsertIfNotExists(new Word { WordCZ = "slovo", WordEN = "word" });
                InsertIfNotExists(new Word { WordCZ = "svět", WordEN = "world" });
                InsertIfNotExists(new Word { WordCZ = "zmínil", WordEN = "mentioned" });
                InsertIfNotExists(new Word { WordCZ = "volněji", WordEN = "leisurely" });
                InsertIfNotExists(new Word { WordCZ = "vyjít", WordEN = "get by" });
                InsertIfNotExists(new Word { WordCZ = "projití bez trestu", WordEN = "get away with" });
                InsertIfNotExists(new Word { WordCZ = "dostat se někam", WordEN = "get to" });
                InsertIfNotExists(new Word { WordCZ = "naznačuje", WordEN = "implies" });
                InsertIfNotExists(new Word { WordCZ = "známky", WordEN = "marks" });
                InsertIfNotExists(new Word { WordCZ = "výsledky", WordEN = "results" });
                InsertIfNotExists(new Word { WordCZ = "doporučení", WordEN = "recommendations" });
                InsertIfNotExists(new Word { WordCZ = "zrcadlí", WordEN = "reflects" });
                InsertIfNotExists(new Word { WordCZ = "varuje", WordEN = "warns" });
                InsertIfNotExists(new Word { WordCZ = "prohlídka města", WordEN = "sightseeing" });
                InsertIfNotExists(new Word { WordCZ = "chudý", WordEN = "poor" });
                InsertIfNotExists(new Word { WordCZ = "spor", WordEN = "fight" });
                InsertIfNotExists(new Word { WordCZ = "propuštěný", WordEN = "fired" });
                InsertIfNotExists(new Word { WordCZ = "průměr", WordEN = "average" });
                InsertIfNotExists(new Word { WordCZ = "prošli", WordEN = "passed" });
                InsertIfNotExists(new Word { WordCZ = "sporný", WordEN = "argued" });
                InsertIfNotExists(new Word { WordCZ = "garantují", WordEN = "guarantee" });
                InsertIfNotExists(new Word { WordCZ = "obviňující", WordEN = "blaming" });
                InsertIfNotExists(new Word { WordCZ = "zodpovědný", WordEN = "responsible" });
                InsertIfNotExists(new Word { WordCZ = "pravidelný", WordEN = "regular" });
                InsertIfNotExists(new Word { WordCZ = "stručně", WordEN = "briefly" });
                InsertIfNotExists(new Word { WordCZ = "objevil se", WordEN = "appeared" });
                InsertIfNotExists(new Word { WordCZ = "upuštěný", WordEN = "dropped" });
                InsertIfNotExists(new Word { WordCZ = "nadpis", WordEN = "headline" });
                InsertIfNotExists(new Word { WordCZ = "jemuž, nimiž", WordEN = "whom" });
                InsertIfNotExists(new Word { WordCZ = "způsob", WordEN = "causing" });
                InsertIfNotExists(new Word { WordCZ = "trable", WordEN = "trouble" });
                InsertIfNotExists(new Word { WordCZ = "můžu, směl bych", WordEN = "might" });
                InsertIfNotExists(new Word { WordCZ = "právník", WordEN = "lawyers" });
                InsertIfNotExists(new Word { WordCZ = "vědec", WordEN = "scientists" });
                InsertIfNotExists(new Word { WordCZ = "zodpovědný", WordEN = "responsible" });
                InsertIfNotExists(new Word { WordCZ = "slza", WordEN = "tear" });
                InsertIfNotExists(new Word { WordCZ = "dokázaný", WordEN = "proved" });
                InsertIfNotExists(new Word { WordCZ = "navzdory", WordEN = "despite" });
                InsertIfNotExists(new Word { WordCZ = "odsouzený", WordEN = "convicted" });
                InsertIfNotExists(new Word { WordCZ = "ilegální", WordEN = "unlawful" });
                InsertIfNotExists(new Word { WordCZ = "skladiště", WordEN = "storage" });
                InsertIfNotExists(new Word { WordCZ = "zdraněný", WordEN = "injured" });
                InsertIfNotExists(new Word { WordCZ = "tajný", WordEN = "secret" });
                InsertIfNotExists(new Word { WordCZ = "umístil", WordEN = "placed" });
                InsertIfNotExists(new Word { WordCZ = "namáhavý", WordEN = "trying" });
                InsertIfNotExists(new Word { WordCZ = "potrestaný", WordEN = "punished" });
                InsertIfNotExists(new Word { WordCZ = "nášlapná mina", WordEN = "landmines" });
                InsertIfNotExists(new Word { WordCZ = "zakopaný", WordEN = "buried" });
                InsertIfNotExists(new Word { WordCZ = "zbraně", WordEN = "weapons" });
                InsertIfNotExists(new Word { WordCZ = "připojil", WordEN = "attached" });
                InsertIfNotExists(new Word { WordCZ = "zahrnutý", WordEN = "involved" });
                InsertIfNotExists(new Word { WordCZ = "zapojený, připojený", WordEN = "connected" });
                InsertIfNotExists(new Word { WordCZ = "nebezpečí", WordEN = "danger" });
                InsertIfNotExists(new Word { WordCZ = "ohrozit", WordEN = "endanger" });
                InsertIfNotExists(new Word { WordCZ = "podobný", WordEN = "alike" });
                InsertIfNotExists(new Word { WordCZ = "průvodce", WordEN = "guides" });
                InsertIfNotExists(new Word { WordCZ = "největší", WordEN = "greates" });
                InsertIfNotExists(new Word { WordCZ = "úřeníky", WordEN = "officials" });
                InsertIfNotExists(new Word { WordCZ = "ječícími", WordEN = "screaming" });
                InsertIfNotExists(new Word { WordCZ = "zvonící", WordEN = "ringing" });
                InsertIfNotExists(new Word { WordCZ = "stát se", WordEN = "become" });
                InsertIfNotExists(new Word { WordCZ = "leží", WordEN = "lies" });
                InsertIfNotExists(new Word { WordCZ = "kopule", WordEN = "dome" });
                InsertIfNotExists(new Word { WordCZ = "obzor", WordEN = "skyline" });
                InsertIfNotExists(new Word { WordCZ = "objevit, odhalit", WordEN = "discover" });
                InsertIfNotExists(new Word { WordCZ = "stál", WordEN = "stood" });
                InsertIfNotExists(new Word { WordCZ = "aktualizovaný", WordEN = "updated" });
                InsertIfNotExists(new Word { WordCZ = "navzdory", WordEN = "despite" });
                InsertIfNotExists(new Word { WordCZ = "zůstal", WordEN = "remained" });
                InsertIfNotExists(new Word { WordCZ = "zvát, pozvat", WordEN = "invite" });
                InsertIfNotExists(new Word { WordCZ = "přidat se, spojovat", WordEN = "join" });
                InsertIfNotExists(new Word { WordCZ = "prozkoumat", WordEN = "explored" });
                InsertIfNotExists(new Word { WordCZ = "světovou třídu", WordEN = "world-class" });
                InsertIfNotExists(new Word { WordCZ = "volný čas", WordEN = "leisure" });
                InsertIfNotExists(new Word { WordCZ = "vybavení", WordEN = "facilities" });
                InsertIfNotExists(new Word { WordCZ = "potěšení", WordEN = "pleasure" });
                InsertIfNotExists(new Word { WordCZ = "vícejazyčné", WordEN = "multilingual" });
                InsertIfNotExists(new Word { WordCZ = "možnosti", WordEN = "possibilities" });
                InsertIfNotExists(new Word { WordCZ = "předpokládaný", WordEN = "supposed" });
                InsertIfNotExists(new Word { WordCZ = "soumrak", WordEN = "dusk" });
                InsertIfNotExists(new Word { WordCZ = "klece", WordEN = "cages" });
                InsertIfNotExists(new Word { WordCZ = "zvýšená", WordEN = "increased" });
                InsertIfNotExists(new Word { WordCZ = "ošetřovatelé", WordEN = "keepers" });
                InsertIfNotExists(new Word { WordCZ = "najednou", WordEN = "suddenly" });
                InsertIfNotExists(new Word { WordCZ = "zaklepat", WordEN = "knock" });
                InsertIfNotExists(new Word { WordCZ = "ospalý", WordEN = "sleepy" });
                InsertIfNotExists(new Word { WordCZ = "obdivovaný", WordEN = "admired" });
                InsertIfNotExists(new Word { WordCZ = "divoký", WordEN = "wild" });
                InsertIfNotExists(new Word { WordCZ = "kritizuje", WordEN = "critised" });
                InsertIfNotExists(new Word { WordCZ = "podivné", WordEN = "strange" });
                InsertIfNotExists(new Word { WordCZ = "pohádka", WordEN = "fairy-tale" });
                InsertIfNotExists(new Word { WordCZ = "zkoužka", WordEN = "tried" });
                InsertIfNotExists(new Word { WordCZ = "prohlídka", WordEN = "tour" });
                InsertIfNotExists(new Word { WordCZ = "průvodce", WordEN = "guide" });
                InsertIfNotExists(new Word { WordCZ = "vede", WordEN = "lead" });
                InsertIfNotExists(new Word { WordCZ = "nemusí", WordEN = "do not have to" });
                InsertIfNotExists(new Word { WordCZ = "ubytování", WordEN = "accommodation" });
                InsertIfNotExists(new Word { WordCZ = "mohou", WordEN = "might" });
                InsertIfNotExists(new Word { WordCZ = "méně", WordEN = "less" });
                InsertIfNotExists(new Word { WordCZ = "rodiště", WordEN = "birthplace" });
                InsertIfNotExists(new Word { WordCZ = "postoupit", WordEN = "submit" });
                InsertIfNotExists(new Word { WordCZ = "tvůrci filmů", WordEN = "filmmakers" });
                InsertIfNotExists(new Word { WordCZ = "podpora, podporující", WordEN = "support" });
                InsertIfNotExists(new Word { WordCZ = "obdržet", WordEN = "receive" });
                InsertIfNotExists(new Word { WordCZ = "pozornost, péče", WordEN = "attention" });
                InsertIfNotExists(new Word { WordCZ = "přání", WordEN = "wish" });
                InsertIfNotExists(new Word { WordCZ = "mezinárodní", WordEN = "internationa" });
                InsertIfNotExists(new Word { WordCZ = "být", WordEN = "be, was/were, been" });
                InsertIfNotExists(new Word { WordCZ = "stavět", WordEN = "build, built, built" });
                InsertIfNotExists(new Word { WordCZ = "koupit", WordEN = "buy, bought, bought" });
                InsertIfNotExists(new Word { WordCZ = "příjít", WordEN = "come, came, come" });
                InsertIfNotExists(new Word { WordCZ = "dělat", WordEN = "do, did, done" });
                InsertIfNotExists(new Word { WordCZ = "pít", WordEN = "drink, drank, drunk" });
                InsertIfNotExists(new Word { WordCZ = "jíst", WordEN = "eat, ate, eaten" });
                InsertIfNotExists(new Word { WordCZ = "padat", WordEN = "fall, fell, fallen" });
                InsertIfNotExists(new Word { WordCZ = "cítit", WordEN = "feel, felt, felt" });
                InsertIfNotExists(new Word { WordCZ = "najít", WordEN = "find, found, found" });
                InsertIfNotExists(new Word { WordCZ = "létat", WordEN = "fly, flew, flown" });
                InsertIfNotExists(new Word { WordCZ = "zapomenout", WordEN = "forget, forgot, forgotten" });
                InsertIfNotExists(new Word { WordCZ = "dostat", WordEN = "get, got, got" });
                InsertIfNotExists(new Word { WordCZ = "dát", WordEN = "give, gave, given" });
                InsertIfNotExists(new Word { WordCZ = "jít", WordEN = "go, went, gone" });
                InsertIfNotExists(new Word { WordCZ = "vlastnit (mám)", WordEN = "have, had, had" });
                InsertIfNotExists(new Word { WordCZ = "slyšet", WordEN = "hear, heard, heard" });
                InsertIfNotExists(new Word { WordCZ = "vědět", WordEN = "know, knew, known" });
                InsertIfNotExists(new Word { WordCZ = "odejít, nechat", WordEN = "leave, left, left" });
                InsertIfNotExists(new Word { WordCZ = "půjčit", WordEN = "lend, lent, lent" });
                InsertIfNotExists(new Word { WordCZ = "udělat", WordEN = "make, made, made" });
                InsertIfNotExists(new Word { WordCZ = "potkat", WordEN = "meet, met, met" });
                InsertIfNotExists(new Word { WordCZ = "platit", WordEN = "pay, paid, paid" });
                InsertIfNotExists(new Word { WordCZ = "dát, položit", WordEN = "put, put, put" });
                InsertIfNotExists(new Word { WordCZ = "číst", WordEN = "read, read, read" });
                InsertIfNotExists(new Word { WordCZ = "běžet", WordEN = "run, ran, run" });
                InsertIfNotExists(new Word { WordCZ = "říci", WordEN = "say, said, said" });
                InsertIfNotExists(new Word { WordCZ = "vidět", WordEN = "see, saw, seen" });
                InsertIfNotExists(new Word { WordCZ = "prodat", WordEN = "sell, sold, sold" });
                InsertIfNotExists(new Word { WordCZ = "poslat", WordEN = "send, sent, sent" });
                InsertIfNotExists(new Word { WordCZ = "sednout", WordEN = "sit, sat, sat" });
                InsertIfNotExists(new Word { WordCZ = "spát", WordEN = "sleep, slept, slept" });
                InsertIfNotExists(new Word { WordCZ = "mluvit", WordEN = "speak, spoke, spoken" });
                InsertIfNotExists(new Word { WordCZ = "strávit, utratit", WordEN = "spend, spent, spent" });
                InsertIfNotExists(new Word { WordCZ = "stát", WordEN = "stand, stood, stood" });
                InsertIfNotExists(new Word { WordCZ = "plavat", WordEN = "swim, swam, swum" });
                InsertIfNotExists(new Word { WordCZ = "brát", WordEN = "take, took, taken" });
                InsertIfNotExists(new Word { WordCZ = "říci", WordEN = "tell, told, told" });
                InsertIfNotExists(new Word { WordCZ = "myslet", WordEN = "think, thought, thought" });
                InsertIfNotExists(new Word { WordCZ = "psát", WordEN = "write, wrote, writen" });
                InsertIfNotExists(new Word { WordCZ = "muset", WordEN = "must, have to" });
                InsertIfNotExists(new Word { WordCZ = "umět, znát", WordEN = "know" });
                InsertIfNotExists(new Word { WordCZ = "mohl bych", WordEN = "could" });
                InsertIfNotExists(new Word { WordCZ = "umět, smět", WordEN = "can" });
                InsertIfNotExists(new Word { WordCZ = "nemuset", WordEN = "dont have to" });
                InsertIfNotExists(new Word { WordCZ = "nesmět", WordEN = "must not" });



                #endregion words

            }
        }

    }
}
