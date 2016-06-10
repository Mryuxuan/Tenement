using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modal
{
    public class placeInfo
    {
        int placeInfoID;

        public int PlaceInfoID
        {
            get { return placeInfoID; }
            set { placeInfoID = value; }
        }
        
        int placeID;

        public int PlaceID
        {
            get { return placeID; }
            set { placeID = value; }
        }
        string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }
        string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        string introduction;

        public string Introduction
        {
            get { return introduction; }
            set { introduction = value; }
        }

        int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        string introduce;

        public string Introduce
        {
            get { return introduce; }
            set { introduce = value; }
        }
        string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        string traffic;

        public string Traffic
        {
            get { return traffic; }
            set { traffic = value; }
        }
        string surrounding;

        public string Surrounding
        {
            get { return surrounding; }
            set { surrounding = value; }
        }
        string information;

        public string Information
        {
            get { return information; }
            set { information = value; }
        }
        string amenities;

        public string Amenities
        {
            get { return amenities; }
            set { amenities = value; }
        }
        string fee;

        public string Fee
        {
            get { return fee; }
            set { fee = value; }
        }
        string tip;

        public string Tip
        {
            get { return tip; }
            set { tip = value; }
        }
    }
}