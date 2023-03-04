﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domains.ManyToMany
{
    public class ActorMovie
    {
        public int ActorId { get; set; }

        public int MovieId { get; set; }


        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
