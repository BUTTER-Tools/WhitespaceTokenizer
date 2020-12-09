using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using PluginContracts;
using OutputHelperLib;


namespace WhitespaceTokenizer
{
    public class WhitespaceTokenizer : Plugin
    {


        public string[] InputType { get; } = { "String" };
        public string OutputType { get; } = "Tokens";

        public bool InheritHeader { get; } = false;
        public Dictionary<int, string> OutputHeaderData { get; set; } = new Dictionary<int, string>() { };

        #region Plugin Details and Info

        public string PluginName { get; } = "Whitespace Tokenizer";
        public string PluginType { get; } = "Tokenizers/Segmenters";
        public string PluginVersion { get; } = "1.0.0";
        public string PluginAuthor { get; } = "Ryan L. Boyd (ryan@ryanboyd.io)";
        public string PluginDescription { get; } = "This plugin will tokenize your texts based on whitespace (e.g., spaces, tabs, newlines) alone. Does not separate punctuation from words. In most cases, the Twitter-Aware Tokenizer is what you will want to use instead of this (unless you have a good reason for whitespace tokenization).";
        public bool TopLevel { get; } = false;
        public string PluginTutorial { get; } = "Coming Soon";


        public Icon GetPluginIcon
        {
            get
            {
                return Properties.Resources.icon;
            }
        }

        #endregion



        public void ChangeSettings()
        {

            MessageBox.Show("This plugin does not have any settings to change.",
                    "No Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

        }





        public Payload RunPlugin(Payload Input)
        {



            Payload pData = new Payload();
            pData.FileID = Input.FileID;
            pData.SegmentID = Input.SegmentID;

            for (int counter = 0; counter < Input.StringList.Count; counter++)
            {

                pData.StringArrayList.Add(Input.StringList[counter].Split((char[])null, StringSplitOptions.RemoveEmptyEntries));
                pData.SegmentNumber.Add(Input.SegmentNumber[counter]);

            }


            return (pData);

        }



        public void Initialize() { }

        public bool InspectSettings()
        {
            return true;
        }

        public Payload FinishUp(Payload Input)
        {
            return (Input);
        }


        #region Import/Export Settings
        public void ImportSettings(Dictionary<string, string> SettingsDict)
        {

        }

        public Dictionary<string, string> ExportSettings(bool suppressWarnings)
        {
            Dictionary<string, string> SettingsDict = new Dictionary<string, string>();
            return (SettingsDict);
        }
        #endregion


    }
}
