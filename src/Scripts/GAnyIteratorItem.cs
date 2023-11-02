using System;

namespace Gx
{
    public class GAnyIteratorItem
    {
        private readonly GAny _nativeObj;
        
        public GAnyIteratorItem(GAny nativeObj)
        {
            if (!nativeObj.Is("GAnyIteratorItem"))
            {
                throw new Exception("Native obj not the current type of object.");
            }

            _nativeObj = nativeObj;
        }

        public GAny Key()
        {
            return _nativeObj.GetItem("key");
        }
        
        public GAny Value()
        {
            return _nativeObj.GetItem("value");
        }
    }
}