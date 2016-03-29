using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using UniversalAppCsharpBindings.Models;

namespace UniversalAppCsharpBindings.Business
{
    public class MovieManager
    {
        /// <summary>
        /// Remark : Can use 'list' as well but we will not able to bind list modifications (CRUD)
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Movie> GetMovies(){
            return new ObservableCollection<Movie>{
                new Movie{Name = "Avatar", Director = "James Cameron", Image = "Assets/avatar.jpg", Year = new DateTime(2009,1,1)},
                new Movie{Name = "Fight Club", Director = "David Fincher", Image = "Assets/fightclub.jpg", Year = new DateTime(1999,1,1)},
                new Movie{Name = "Forrest Gump", Director = "Robert Zemeckis", Image = "Assets/forrestgump.jpg", Year = new DateTime(1994,1,1)},
                new Movie{Name = "Inception", Director = "Christophe Nolan", Image = "Assets/inception.jpg", Year = new DateTime(2010,1,1)},
                new Movie{Name = "Pulp fiction", Director = "Quentin Tarentino", Image = "Assets/pulpfiction.jpg", Year = new DateTime(1994,1,1)},
		        new Movie{Name = "Intouchables", Director = "Olivier Nakache", Image = "Assets/intouchables.jpg", Year = new DateTime(2011,1,1)},
		        new Movie{Name = "Gran Torino", Director = "Clint Eastwood", Image = "Assets/grantorino.jpg", Year = new DateTime(2008,1,1)},
		        new Movie{Name = "Django", Director = "Quentin Tarentino", Image = "Assets/django.jpg", Year = new DateTime(2013,1,1)}
            };
        }
    }
}
