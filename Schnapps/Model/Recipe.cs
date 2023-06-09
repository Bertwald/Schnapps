﻿namespace Schnapps.Model {
    public class Recipe
    {
        #region Properties
        public string DrinkId { get; set; }
        public string Alternative { get; set; }
        public string DrinkName { get; set; }
        public List<string> Ingredients { get; set; }
        public string Instructions { get; set; }
        public Rating Rating { get; set; }
        public string Comment { get; set; }
        public string Imageurl { get; set; }
        public bool IsAlcoholic { get; set; }
        public string VideoURL { get; set; }
        #endregion
    }
}
