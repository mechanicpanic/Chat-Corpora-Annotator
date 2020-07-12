using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer
{
    public static class HistogramHelper
    {
        public enum BucketizeDirectionEnum
        {
            LowerBoundInclusive,
            UpperBoundInclusive
        }


        public static int[] Bucketize(this IList<int> source, int totalBuckets, BucketizeDirectionEnum inclusivity = BucketizeDirectionEnum.LowerBoundInclusive)
        {
            var min = source.Min();
            var max = source.Max();
            var buckets = new int[totalBuckets];
            var bucketSize = (max - min) / totalBuckets;

            if (inclusivity == BucketizeDirectionEnum.LowerBoundInclusive)
            {
                foreach (var value in source)
                {
                    int bucketIndex = (int)((value - min) / bucketSize);
                    if (bucketIndex == totalBuckets)
                        continue;
                    buckets[bucketIndex]++;
                }
            }
            else
            {
                foreach (var value in source)
                {
                    int bucketIndex = (int)Math.Ceiling((value - min) / (double) bucketSize) - 1;
                    if (bucketIndex < 0)
                        continue;
                    buckets[bucketIndex]++;
                }
            }

            return buckets;
        }
    }
}
