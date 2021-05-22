using DataTransferObject;

namespace DataAccessLayer
{
    public class D_CAUHINHSMTP : DataProcess
    {

        public O_CAUHINHSMTP DuLieu()
        {
            return LayMotDongDonGian<O_CAUHINHSMTP>();
        }
    }
}
