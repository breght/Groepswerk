﻿#pragma checksum "..\..\..\..\Layout\Huren.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "02E58A83AC75F088EC985CBA50537FEA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Front_end_C {
    
    
    /// <summary>
    /// Huren
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class Huren : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\..\Layout\Huren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Front_end_C.Huren Window;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Layout\Huren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Layout\Huren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpVan;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Layout\Huren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpTot;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Layout\Huren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHuren;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Layout\Huren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Layout\Huren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAutoDetails;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Layout\Huren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPrijs;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Front end C;component/layout/huren.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Layout\Huren.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Window = ((Front_end_C.Huren)(target));
            
            #line 7 "..\..\..\..\Layout\Huren.xaml"
            this.Window.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.dtpVan = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.dtpTot = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.btnHuren = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Layout\Huren.xaml"
            this.btnHuren.Click += new System.Windows.RoutedEventHandler(this.btnHuren_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Layout\Huren.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lblAutoDetails = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblPrijs = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

