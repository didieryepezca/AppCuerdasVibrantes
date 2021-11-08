#pragma checksum "C:\Users\LENOVO\Documents\Visual Studio 2019\Projects\AppCuerdasVibrantes\Views\Piezometro\PiezometricHeadsCharts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa4f62f42a5a0a976c0a84d066ddfce1456cb04d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Piezometro_PiezometricHeadsCharts), @"mvc.1.0.view", @"/Views/Piezometro/PiezometricHeadsCharts.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\LENOVO\Documents\Visual Studio 2019\Projects\AppCuerdasVibrantes\Views\_ViewImports.cshtml"
using AppCuerdasVibrantes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\Documents\Visual Studio 2019\Projects\AppCuerdasVibrantes\Views\_ViewImports.cshtml"
using AppCuerdasVibrantes.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa4f62f42a5a0a976c0a84d066ddfce1456cb04d", @"/Views/Piezometro/PiezometricHeadsCharts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f28f54b7cc1ae15a263eaaef7a218f2b36a3c9f8", @"/Views/_ViewImports.cshtml")]
    public class Views_Piezometro_PiezometricHeadsCharts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE HTML>\r\n");
#nullable restore
#line 2 "C:\Users\LENOVO\Documents\Visual Studio 2019\Projects\AppCuerdasVibrantes\Views\Piezometro\PiezometricHeadsCharts.cshtml"
  
    ViewData["Title"] = "PiezometricHeadsCharts";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">


    window.onload = funPiezometroComboCheckbox;

    function funPiezometroComboCheckbox() {

        var count = 1;
        var select = '';

        var url = ""/Piezometro/FunTraerPiezometrosComboCheckBox"";
        $.get(url, { status: ""ACTIVO"" }, function (data) {                          

            //console.log(data);

            data.forEach(function (element) {

                //$('#opt' + count).remove();

                select = select + '<li><div class=""form-group""><label><input id=""' + element.piezometro + '-' + count + '"" type=""checkbox"" value=""' + element.piezometro + '"" onclick=""PiezometrosAddCheckBox()"">' + element.piezometro + '</label></div></li>';                

                count = count + 1;
            });

            $('#piezometrosCombo').append(select);

        });
    }

    var selectedPiezometros = [];

    function PiezometrosAddCheckBox()
    {
        $(document).on('click', jQuery(""input[type=check");
            WriteLiteral(@"box]:checked""), function () {

                selectedPiezometros = []; //limpiar array antes de volver a llenar

                var n = jQuery(""input[type=checkbox]:checked"").length;
                if (n > 0) {
                    jQuery(""input[type=checkbox]:checked"").each(function () {

                        selectedPiezometros.push($(this).val());
                    });
                }
                //$(""#piezometrosBusqueda"").val(selectedPiezometros);
                //console.log(selectedPiezometros);
            });
    }

    function FunGraficar()
    {
        var fecha_inicio = $('#fecI').val();
        var fecha_fin = $('#fecF').val();
        var intervaloY =  Number($('#inputY').val()); 

        console.log(intervaloY);

        var chart = new CanvasJS.Chart(""chartContainer"", {

            zoomEnabled: true,
            exportEnabled: true,
            animationEnabled: true,
            theme: ""light2"",
            title: {
                text: ""MSSF - La Q");
            WriteLiteral(@"uinua Pila de Lixiviación TSF - DAM Norte -  Piezómetros de Cuerda Vibrante"",
                fontSize: 25
            },
            axisX: {
                interval: 1,
                crosshair: {
                    enabled: true,
                    snapToDataPoint: true
                }
            },
            axisY: [{
                title: ""Cabeza Piezométrica (metros de agua)"",
                lineColor: ""#C24642"",
                tickColor: ""#C24642"",
                labelFontColor: ""#C24642"",
                titleFontColor: ""#C24642"",
                includeZero: false,
                interval: intervaloY,
                suffix: "" m"",
                crosshair: {
                    enabled: true
                }
            },
            ],
            toolTip: {
                shared: true
            },
            legend: {
                cursor: ""pointer"",
                itemclick: toggleDataSeries,
                fontSize: 16,
            },
            data: [    ]
          ");
            WriteLiteral(@"  
        });
        chart.render();

        
        function toggleDataSeries(e) {
            if (typeof (e.dataSeries.visible) === ""undefined"" || e.dataSeries.visible) {
                e.dataSeries.visible = false;
            } else {
                e.dataSeries.visible = true;
            }
            e.chart.render();
        }      
        //-------------------- añadiendo nueva serie de datos de puntos al grafico a traves del array creado
        //console.log(selectedPiezometros);

        //-------------------- MANERA EJEMPLO
        //var type = ""line"";
        //var fillOpacity = .4;
        //var dataPoints = [];
        //var dataPoints2 = [];
        //for (var i = 0; i < 20; i++) {
        //    dataPoints.push({ y: Math.random() * 10 - 5 });
        //    dataPoints2.push({ y: Math.random() * 8 - 3 });
        //}
        //chart.options.data.push({ type: type, fillOpacity: fillOpacity, dataPoints: dataPoints });
        //chart.options.data.push({ type: type, fillOpaci");
            WriteLiteral(@"ty: fillOpacity, dataPoints: dataPoints2 });
        //chart.render();    
        //-------------------- MANERA EJEMPLO
       
        //var count = -1;

        var arrayContainer = [];                
        var piezometroArray = new Array();

        selectedPiezometros.forEach(function (piezometro, indice, array) {  //-----------------END ARRAY FOREACH PIEZOMETROS SELECCIONADOS

            //console.log(""En el índice "" + indice + "" hay este valor: "" + piezometro);
            //var piezometro = ""TOVP14-13"";
            piezometroArray[indice] = new Array();          

            var type = ""line"";
            var fillOpacity = .4;    
            var name;

            $.ajax({
                type: ""GET"",
                url: ""/Piezometro/FunGraficar?fecha_inicio="" + fecha_inicio + ""&fecha_fin="" + fecha_fin + ""&piezometro="" + piezometro,
                contentType: false,
                processData: false,
                success: function (data) {                    
         ");
            WriteLiteral(@"           
                    // FUNCIONA
                    data.forEach(function (element) {
                                      
                        if (element.piezometro == piezometro)
                        {
                            piezometroArray[indice].push({ y: element.piezometric_head, label: moment(element.fecha).format('DD/MM/YYYY') });     
                            //console.log(""entro""); 
                        }                                                                                 
                    });                      
                   arrayContainer.push(piezometroArray[indice]);
                }
                 
            });//--------------------------------END AJAX

            chart.options.data.push({ type: type, name: piezometro, showInLegend: true, fillOpacity: fillOpacity, dataPoints: piezometroArray[indice] }); /// AÑADE LOS PIEZOMETROS QUE DESEAMOS GRAFICAR
            chart.render();           
        });//---------------------");
            WriteLiteral(@"------------ END ARRAY FOREACH PIEZOMETROS SELECCIONADOS

        //console.log(arrayContainer); 
    }

    function isNumber(evt) {
        var iKeyCode = (evt.which) ? evt.which : evt.keyCode
        if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
            return false;

        return true;
    }


</script>


<div class=""block-header"">
    <div class=""row"">
        <div class=""col-lg-5 col-md-5 col-sm-12"">
            <h2>
                Graficar Piezometric Heads
                <small>Graficos</small>
            </h2>
        </div>
        <div class=""col-lg-7 col-md-7 col-sm-12 text-right"">
            <ul class=""breadcrumb float-md-right"">
                <li class=""breadcrumb-item""><a");
            BeginWriteAttribute("href", " href=\"", 7027, "\"", 7034, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"zmdi zmdi-home\"></i><strong>Cuerdas Vibrantes</strong></a></li>\r\n                <li class=\"breadcrumb-item active\">Graficar Piezometric Heads</li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa4f62f42a5a0a976c0a84d066ddfce1456cb04d11162", async() => {
                WriteLiteral(@"

    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""card"">

                <div class=""header"">
                    <h2><strong>Graficar</strong> Piezometric Heads <small></small></h2>
                </div>
                <div class=""header"">
                    <div class=""row clearfix"">

                        <div class=""col-lg-12 col-md-12"">
                            <div class=""form-group"">

                                <p style=""color:red""><strong>Seleccione el(los) piezometro(s), un rango de fechas y el intervalo del eje Y para graficar la data</strong></p>
                            </div>
                        </div>
                    </div>

                    <div class=""row clearfix"">


                        <div class=""col-lg-3 col-md-12"">
                            <div class=""form-group"">

                                <ul>
                                    <li class=""dropdown"">
                                       ");
                WriteLiteral(" <a href=\"#\" data-toggle=\"dropdown\" class=\"dropdown-toggle\"><strong>Piezometros</strong><b class=\"caret\"></b></a>\r\n                                        <ul class=\"dropdown-menu\" id=\"piezometrosCombo\">\r\n");
                WriteLiteral(@"                                        </ul>
                                    </li>
                                </ul>

                            </div>
                        </div>



                        <div class=""col-lg-2 col-md-12"">
                            <div class=""form-group"">
");
#nullable restore
#line 261 "C:\Users\LENOVO\Documents\Visual Studio 2019\Projects\AppCuerdasVibrantes\Views\Piezometro\PiezometricHeadsCharts.cshtml"
                                  
                                    string desde = ViewBag.Fecha_Ini;

                                    if (desde.Equals("0001-01-01"))
                                    {
                                        desde = DateTime.Today.ToString("yyyy-MM-dd");
                                    }
                                

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <label class=\"control-label\"><strong>Desde</strong></label>\r\n                                <input type=\"date\" id=\"fecI\" class=\"form-control\" name=\"Fecha_Ini\"");
                BeginWriteAttribute("value", " value=\"", 10046, "\"", 10060, 1);
#nullable restore
#line 270 "C:\Users\LENOVO\Documents\Visual Studio 2019\Projects\AppCuerdasVibrantes\Views\Piezometro\PiezometricHeadsCharts.cshtml"
WriteAttributeValue("", 10054, desde, 10054, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n\r\n                            </div>\r\n                        </div>\r\n\r\n                        <div class=\"col-lg-2 col-md-12\">\r\n                            <div class=\"form-group\">\r\n");
#nullable restore
#line 277 "C:\Users\LENOVO\Documents\Visual Studio 2019\Projects\AppCuerdasVibrantes\Views\Piezometro\PiezometricHeadsCharts.cshtml"
                                  
                                    string hasta = ViewBag.Fecha_Fin;

                                    if (hasta.Equals("0001-01-01"))
                                    {
                                        hasta = DateTime.Today.ToString("yyyy-MM-dd");
                                    }
                                

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <label class=\"control-label\"><strong>Hasta</strong></label>\r\n                                <input type=\"date\" id=\"fecF\" class=\"form-control\" name=\"Fecha_Fin\"");
                BeginWriteAttribute("value", " value=\"", 10818, "\"", 10832, 1);
#nullable restore
#line 286 "C:\Users\LENOVO\Documents\Visual Studio 2019\Projects\AppCuerdasVibrantes\Views\Piezometro\PiezometricHeadsCharts.cshtml"
WriteAttributeValue("", 10826, hasta, 10826, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">

                            </div>
                        </div>

                        <div class=""col-lg-1 col-md-12"">
                            <div class=""form-group"">                            
                                <label class=""control-label""><strong>Intevalo eje Y</strong></label>
                                <input type=""text"" id=""inputY"" onkeypress=""javascript:return isNumber(event)"" class=""form-control"">

                            </div>
                        </div>



                        <div class=""col-lg-2 col-md-12"">
                            <div class=""form-group"">
                                <label class=""control-label"">.</label>
                                <button class=""btn btn-raised btn-round btn-danger form-control"" id=""btnGraficar"" onclick=""FunGraficar();"" style=""float:left;"">Graficar !</button>
                            </div>
                        </div>
                    </div>
                 
                </d");
                WriteLiteral(@"iv>

            </div>
        </div>
    </div>



    <div class=""row clearfix"">
        <div class=""col-md-12"">
            <div class=""card parents-list"">
                <div class=""header"">
                    <h2><strong>Grafico</strong> de Cabezas Piezometricas</h2>

                </div>

                <div class=""card-body"">

                    <div id=""chartContainer"" style=""height: 500px; width: auto;""></div>


                </div>

                

            </div>

        </div>
    </div>

    <script src=""https://momentjs.com/downloads/moment.js""></script>
    <script src=""https://canvasjs.com/assets/script/canvasjs.min.js""></script>



");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
