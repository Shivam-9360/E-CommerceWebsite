using System.Web;
using System.Web.Optimization;

namespace ECommerceWebsite
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Layout/js").Include(
                        "~/Scripts/layout*"));

            bundles.Add(new ScriptBundle("~/Login/js").Include(
                        "~/Scripts/login*"));

            bundles.Add(new ScriptBundle("~/Shop/js").Include(
                        "~/Scripts/shop*"));

            bundles.Add(new ScriptBundle("~/Cart/js").Include(
                        "~/Scripts/cart*"));

            bundles.Add(new ScriptBundle("~/Product/js").Include(
                        "~/Scripts/lightslider*",
                        "~/Scripts/product*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/layout.css"));

            bundles.Add(new StyleBundle("~/Home/css").Include(
                      "~/Content/home.css"));

            bundles.Add(new StyleBundle("~/Login/css").Include(
                      "~/Content/login.css"));

            bundles.Add(new StyleBundle("~/AboutUs/css").Include(
                      "~/Content/aboutus.css"));

            bundles.Add(new StyleBundle("~/ContactUs/css").Include(
                      "~/Content/contactus.css"));

            bundles.Add(new StyleBundle("~/Shop/css").Include(
                      "~/Content/shop.css"));

            bundles.Add(new StyleBundle("~/Cart/css").Include(
                      "~/Content/cart.css"));

            bundles.Add(new StyleBundle("~/Product/css").Include(
                      "~/Content/product.css",
                      "~/Content/lightslider.css"));
        }
    }
}
