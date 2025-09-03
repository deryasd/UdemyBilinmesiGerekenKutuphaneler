using System.Drawing;

namespace HangFire.Web.BackgroundJobs
{
    public class DelayedJobs
    {
        public static string AddWatermarkJob(string fileName, string watermarkText)
        {
            return Hangfire.BackgroundJob.Schedule(() => ApplyWatermark(fileName, watermarkText), TimeSpan.FromSeconds(30));
        }
        public static void ApplyWatermark(string fileName, string watermarkText)
        {
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures", fileName);
            string targetPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures", "watermarks", fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(targetPath)!);

            using (var bitmap = new Bitmap(sourcePath))
            {
                using (var tempBitmap = new Bitmap(bitmap.Width, bitmap.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(tempBitmap))
                    {
                        graphics.DrawImage(bitmap, 0, 0);

                        using var font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
                        using var brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0));

                        var point = new PointF(20, bitmap.Height - 50);

                        graphics.DrawString(watermarkText, font, brush, point);

                        tempBitmap.Save(targetPath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
        }

    }


}
