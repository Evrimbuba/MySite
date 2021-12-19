using System;

namespace MyProfileSite.Shared.Models
{
    public class Pagination
    {
        /// <summary>
        /// Sayfalama sistemi
        /// </summary>
        /// <param name="totalEntityCount">Toplam entity sayısı</param>
        /// <param name="entityCountPerPage">Sayfa başı gösterilecek entity sayısı</param>
        /// <param name="current">Seçili sayfa</param>
        public Pagination(int totalEntityCount, int entityCountPerPage = 25, int current = 1)
        {
            if (entityCountPerPage == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var showPageCount = (int)Math.Ceiling((totalEntityCount * 1.0) / entityCountPerPage);
            Total = totalEntityCount % entityCountPerPage == 0 ? totalEntityCount / entityCountPerPage : (totalEntityCount / entityCountPerPage) + 1;
            Start = current - (showPageCount / 2);
            Finish = current + (showPageCount / 2);
            Current = current;

            if (Total > showPageCount)
            {
                if (current - (showPageCount / 2) > 0)
                {
                    if (current + (showPageCount / 2) < Total)
                    {
                        Start = current - (showPageCount / 2);
                        Finish = current + (showPageCount / 2);
                    }
                    else
                    {
                        Start = Total - showPageCount;
                        Finish = Total;
                    }
                }
                else
                {
                    Start = 1;
                    Finish = showPageCount;
                }
            }
            else
            {
                Start = 1;
                Finish = Total;
            }
        }

        public int Start { get; set; }
        public int Finish { get; set; }
        public int Current { get; set; }
        public int Total { get; set; }
    }
}