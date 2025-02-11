using AspNet.Models;

namespace AspNet.Services
{
    public class ProfileService : IProfileService
    {
        public AboutMeViewModel GetAboutMeData()
        {
            // constructs an instance of AboutMeViewModel with some hardcoded data
            return new AboutMeViewModel
            {
                Jobs = new Dictionary<string, (string, string)>
                {
                    { "Software Engineer", ("&#128187", "OSU CASS") },
                    { "ML Researcher", ("&#129504", "STAR Lab") }
                },
                Skills = new Dictionary<string, string>
                {
                    {"Languages", "Python, JavaScript, C/C++, SQL, C#, Java, HTML, CSS, x86 ASM" },
                    {"Technologies", "Node.js, ASP.NET, REST, Vue.js, Express, Jest, Vite, MySQL, PostgreSQL, Firebase" },
                    {"Dev Tools", "Git, GitHub, Docker, Visual Studio, VSCode, IntelliJ, Jupyter, Google Colab" },
                    {"Libraries", "NumPy, pandas, Matplotlib, Scikit-Learn, Tensorflow, PyTorch, Tkinter" }
                },
                Hobbies = new List<string>
                {
                    "Hiking", "Photography", "Drone Flying", "Watching Movies", "Playing GTA"
                }
            };
        }
    }
}
