using Domain;
using Newtonsoft.Json;
using Persistence.JsonFile.Repositories;
using Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace Persistence.JsonFile
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBlogPostRepository BlogPosts { get; }

        public IResumeRepository Resume { get; }

        private IDataFileProvider _dataFileProvider;

        public UnitOfWork(IDataFileProvider dataFileProvider)
        {
            _dataFileProvider = dataFileProvider;
            BlogPosts = new BlogPostRepository(dataFileProvider);
            Resume = new ResumeRepository(dataFileProvider);
            InitResume();
        }

        private void InitResume()
        {
            if (Resume.Get(null) == null)
            {
                Resume.Add(CreateDefaultResume());
                SaveToFile(Resume);
            }
        }

        private Resume CreateDefaultResume()
        {
            return new Domain.Resume
            {
                Id = Guid.Parse("7c0a0f9d-1e0f-41a8-b8e3-0d4aae07910e"),
                Biography = @"<p>Urodziłem się 4 lipca 1986 r. Mieszkańcem Sosnowca jestem od urodzenia. Wychowałem się w rodzinie od lat związanej z regionem Zagłębia Dąbrowskiego. W 2005 roku ukończyłem z wyróżnieniem III Liceum Ogólnokształcące im. Bolesława Prusa w Sosnowcu, otrzymując na tę okoliczność Medal Bolesława Prusa, będąc tym samym jednym z ponad 200 laureatów tego zaszczytnego wyróżnienia.</p>
<p>Jestem absolwentem nauk politycznych ze specjalnością europeistyka na Wydziale Nauk Społecznych Uniwersytetu Śląskiego w Katowicach. Ponadto ukończyłem Podyplomowe Studia Samorządu Terytorialnego na Wydziale Prawa i Administracji UŚ oraz studia podyplomowe PR - nowoczesna komunikacja w praktyce na Uniwersytecie Ekonomicznym w Katowicach. Aktualnie jestem słuchaczem studiów doktoranckich na Wydziale Nauk Społecznych UŚ.</p>
<p>Posiadam certyfikat Ministerstwa Skarbu Państwa uprawniający do zasiadania w radach nadzorczych spółek kapitałowych.</p>
<p>Od lat młodzieńczych pociągała mnie działalność społeczno - polityczna. Działalność w SLD rozpoczynałem jako sympatyk w wieku 16 lat. Członkiem partii jestem od września 2004 r. W ramach działalności w SLD pełnię szereg funkcji związanych z funkcjonowaniem Sojuszu w tym funkcję wiceprzewodniczącego partii w Sosnowcu. Brałem także udział w przygotowaniu oraz prowadzeniu wszystkich kampanii wyborczych SLD w Sosnowcu od 2002 r.</p>
<p>Od września 2009 r, do marca 2012 r. byłem Przewodniczącym Powiatowego Koła Federacji Młodych Socjaldemokratów w Sosnowcu - statutowej młodzieżówki SLD. Od marca 2010 r. do stycznia 2015 r. pełniłem funkcję wiceprzewodniczącego struktur wojewódzkich tej organizacji, by ostatecznie 10 stycznia 2015 r. stanąć na ich czele. Ponadto od maja 2012 r. jestem członkiem Rady Krajowej FMS.</p>
<p>Ponadto byłem uczestnikiem prestiżowego szkolenia z zakresu komunikacji społecznej o nazwie Szkoła Liderów, organizowanego przez Wyższą Szkołę Biznesu w Dąbrowie Górniczej, pod patronatem profesora Jacka Wodza, prestiżowej XIV edycji Szkoły Liderów Społeczeństwa Obywatelskiego organizowanej przez stowarzyszenie Szkoła Liderów w Warszawie oraz jestem absolwentem XI edycji Programu Centrum Kreowania Liderów Kuźnia zorganizowanej przez Instytut Regionalny w Katowicach. Uczestniczyłem także w projekcie „Nie narzekam – kandyduję!“ realizowanym przez fundacje Friedricha Eberta oraz Dom Współpracy Polsko - Niemieckiej.</p>
<p>W wyborach samorządowych przeprowadzonych 21 listopada 2010 roku po raz pierwszy uzyskałem mandat radnego Rady Miejskiej w Sosnowcu. W kolejnej samorządowej elekcji, która odbyła się 16 listopada 2014 r. mieszkancy Pogoni i Milowic ponownie obdarzyli mnie swoim zaufaniem. oddając na mnie największą liczbę głosów ze wszystkich startujących kandydatów.</p>
<p>Od lutego 2009 r. do listopada 2011 r. pełniłem funkcje społecznego asystenta Posła na Sejm RP Witolda Klepacza.</p>",
                Positions = new List<ResumePosition>
                {
                    new ResumePosition
                    {
                        Id = Guid.Parse("c3b207d1-c002-42c8-ab46-e9598ccfa7d8"),
                        DateRange = "od I 2015",
                        Description = "Przewodniczący Federacji Młodych Socjaldemokratów woj. śląskiego"
                    },
                    new ResumePosition
                    {
                        Id = Guid.Parse("ee4c59b1-2f10-4de1-8d49-c998490ceff0"),
                        DateRange = "od XII 2014",
                        Description = "Wiceprzewodniczący Rady Miejskiej w Sosnowcu"
                    },
                    new ResumePosition
                    {
                        Id = Guid.Parse("f28ea040-c476-4be9-aabd-3a808037a106"),
                        DateRange = "od II 2014",
                        Description = "Członek Śląskiej Rady Wojewódzkiej Sojuszu Lewicy Demokratycznej"
                    },
                    new ResumePosition
                    {
                        Id = Guid.Parse("93e37fb9-5cf3-458f-b9be-28406a394296"),
                        DateRange = "od V 2012",
                        Description = "Członek Rady Krajowej Federacji Młodych Socjaldemokratów"
                    }
                }
            };
        }

        public int Complete()
        {
            SaveToFile(BlogPosts);
            SaveToFile(Resume);
            return 1;
        }

        private bool SaveToFile<T>(IGetAllRepository<T> entities) where T : IEntity
        {
            var data = JsonConvert.SerializeObject(entities.GetAll());
            return _dataFileProvider.UpdateFileText(typeof(T).Name, data);
        }

        public void Dispose()
        {
            
        }
    }
}
