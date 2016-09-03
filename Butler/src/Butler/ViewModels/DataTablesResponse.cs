using System.Collections.Generic;
using Butler.Models;

namespace Butler.Controllers
{
    internal class DataTablesResponse
    {
        private int draw;
        private IEnumerable<Dish> filteredData;
        private int iTotalDisplayRecords;
        private int iTotalRecords;

        public DataTablesResponse(int draw, IEnumerable<Dish> filteredData, int iTotalDisplayRecords, int iTotalRecords)
        {
            this.Draw = draw;
            this.FilteredData = filteredData;
            this.ITotalDisplayRecords = iTotalDisplayRecords;
            this.ITotalRecords = iTotalRecords;
        }

        public int Draw
        {
            get
            {
                return draw;
            }

            set
            {
                draw = value;
            }
        }

        public IEnumerable<Dish> FilteredData
        {
            get
            {
                return filteredData;
            }

            set
            {
                filteredData = value;
            }
        }

        public int ITotalDisplayRecords
        {
            get
            {
                return iTotalDisplayRecords;
            }

            set
            {
                iTotalDisplayRecords = value;
            }
        }

        public int ITotalRecords
        {
            get
            {
                return iTotalRecords;
            }

            set
            {
                iTotalRecords = value;
            }
        }
    }
}