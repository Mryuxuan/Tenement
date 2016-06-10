using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modal
{
    public class Place
    {
        int placeID;

        public int PlaceID
        {
            get { return placeID; }
            set { placeID = value; }
        }
        string places;

        public string Places
        {
            get { return places; }
            set { places = value; }
        }
        string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }
    }
}