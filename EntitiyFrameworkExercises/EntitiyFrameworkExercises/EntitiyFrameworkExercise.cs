using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EntitiyFrameworkExercises
{
    class EntitiyFrameworkExercise
    {
        static void Main(string[] args)
        {

            BlogDBContent blogDbContent = new BlogDBContent();
            blogDbContent.Database.Initialize(true);

        }
    }
}
