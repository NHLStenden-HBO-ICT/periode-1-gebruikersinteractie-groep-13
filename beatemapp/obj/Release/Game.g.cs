﻿#pragma checksum "..\..\Game.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7958054ADEB656C57E20C93F8412828F07AAFB29A72B4B08DDF0B29A7A512022"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BeatEmApp;
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


namespace BeatEmApp {
    
    
    /// <summary>
    /// Game
    /// </summary>
    public partial class Game : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border GameBorder;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas PlayerCanvas;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle BorderGame;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Player1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Player2;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Enemy1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Enemy2;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button menu;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Player_contents;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Player2_contents;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock vijand1_levens;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock vijand2_levens;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BeatEmApp;component/game.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Game.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GameBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.PlayerCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 11 "..\..\Game.xaml"
            this.PlayerCanvas.KeyDown += new System.Windows.Input.KeyEventHandler(this.OnKeyDown);
            
            #line default
            #line hidden
            
            #line 11 "..\..\Game.xaml"
            this.PlayerCanvas.KeyUp += new System.Windows.Input.KeyEventHandler(this.OnKeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BorderGame = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 4:
            this.Player1 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 5:
            this.Player2 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 6:
            this.Enemy1 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 7:
            this.Enemy2 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 8:
            this.menu = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\Game.xaml"
            this.menu.Click += new System.Windows.RoutedEventHandler(this.OnClick1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Player_contents = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.Player2_contents = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.vijand1_levens = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.vijand2_levens = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
