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

        public static List<int> RemoveOutliers(List<int> source, int cutoff)
        {
            var clean = new List<int>();
            for(int i = 0; i < source.Count; i++)
            {
                if (source[i] < cutoff)
                {
                    clean.Add(source[i]);
                }
            }
            return clean;
        }

        public static int[] Bucketize(List<int> source, int totalBuckets, BucketizeDirectionEnum inclusivity = BucketizeDirectionEnum.LowerBoundInclusive)
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
