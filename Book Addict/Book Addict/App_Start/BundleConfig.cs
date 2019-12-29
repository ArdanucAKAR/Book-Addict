using System.Web;
using System.Web.Optimization;

namespace Book_Addict
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                            "~/asset/vendor/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery.val").Include(
                            "~/asset/vendor/jquery.validation/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery.unobtrusive").Include(
                        "~/asset/vendor/jquery.unobtrusive.validation/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jquery.validate.unobtrusive").Include(
                        "~/asset/vendor/jquery.unobtrusive/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/theme.init").Include(
                        "~/asset/js/theme.init.js"));

            bundles.Add(new ScriptBundle("~/Scripts/modernizr").Include(
                        "~/asset/vendor/modernizr/modernizr.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/theme").Include(
                        "~/asset/js/theme.js"
                        ));

            bundles.Add(new ScriptBundle("~/Scripts/theme/resume").Include(
                        "~/asset/js/demos/demo-resume.js"
                        ));

            bundles.Add(new ScriptBundle("~/Scripts/plugin").Include(
                        "~/asset/vendor/rs-plugin/js/jquery.themepunch.tools.min.js",
                        "~/asset/vendor/rs-plugin/js/jquery.themepunch.revolution.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/Scripts/vendor").Include(
                        "~/asset/vendor/jquery/jquery.min.js",
                        "~/asset/vendor/jquery.appear/jquery.appear.min.js",
                        "~/asset/vendor/jquery.easing/jquery.easing.min.js",
                        "~/asset/vendor/jquery.cookie/jquery.cookie.min.js",
                        "~/asset/vendor/popper/umd/popper.min.js",
                        "~/asset/vendor/bootstrap/js/bootstrap.min.js",
                        "~/asset/vendor/common/common.min.js",
                        "~/asset/vendor/jquery.easy-pie-chart/jquery.easypiechart.min.js",
                        "~/asset/vendor/jquery.gmap/jquery.gmap.min.js",
                        "~/asset/vendor/jquery.lazyload/jquery.lazyload.min.js",
                        "~/asset/vendor/isotope/jquery.isotope.min.js",
                        "~/asset/vendor/owl.carousel/owl.carousel.min.js",
                        "~/asset/vendor/magnific-popup/jquery.magnific-popup.min.js",
                        "~/asset/vendor/vide/jquery.vide.min.js",
                        "~/asset/vendor/vivus/vivus.min.js"
                        ));
            #endregion
            #region Styles
            bundles.Add(new StyleBundle("~/Styles/theme/band").Include(
                        "~/asset/css/demos/demo-band.css"
                        ));

            bundles.Add(new StyleBundle("~/Styles/theme/resume").Include(
                        "~/asset/css/demos/demo-resume.css"
                        ));

            bundles.Add(new StyleBundle("~/Styles/skin/default").Include(
                        "~/asset/css/skins/default.css"
                        ));

            bundles.Add(new StyleBundle("~/Styles/skin/resume").Include(
                        "~/asset/css/skins/skin-resume.css"
                        ));

            bundles.Add(new StyleBundle("~/Styles/skin/band").Include(
                        "~/asset/css/skins/skin-band.css"
                        ));

            bundles.Add(new StyleBundle("~/Styles/plugin").Include(
                        "~/asset/vendor/rs-plugin/css/settings.css",
                        "~/asset/vendor/rs-plugin/css/layers.css",
                        "~/asset/vendor/rs-plugin/css/navigation.css"
                        ));

            bundles.Add(new StyleBundle("~/Styles/theme").Include(
                        "~/asset/css/theme.css",
                        "~/asset/css/theme-elements.css",
                        "~/asset/css/theme-blog.css",
                        "~/asset/css/theme-shop.css"
                        ));

            bundles.Add(new StyleBundle("~/Styles/vendor").Include(
                        "~/asset/vendor/bootstrap/css/bootstrap.min.css",
                        "~/asset/vendor/fontawesome-free/css/all.min.css",
                        "~/asset/vendor/animate/animate.min.css",
                        "~/asset/vendor/simple-line-icons/css/simple-line-icons.min.css",
                        "~/asset/vendor/owl.carousel/assets/owl.carousel.min.css",
                        "~/asset/vendor/owl.carousel/assets/owl.theme.default.min.css",
                        "~/asset/vendor/magnific-popup/magnific-popup.min.css"
                        ));
            #endregion        
            //BundleTable.EnableOptimizations = true;
        }
    }
}
