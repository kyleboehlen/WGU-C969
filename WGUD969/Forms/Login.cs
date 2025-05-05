using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WGUD969.Factories;
using MySql.Data.MySqlClient;
//using Microsoft.Extensions.DependencyInjection;
using WGUD969.Services;
using WGUD969.Models;
using WGUD969.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace WGUD969.Forms
{
    public partial class Login : Form
    {
        private readonly ILocationService _LocationService;
        private readonly ITranslationService _Translator;
        private readonly IAuthService _AuthService;
        private readonly IServiceProvider _ServiceProvider;
        private IUserLocation _UserLocation;
        private Dictionary<string, Language> _LanguageLabels = new Dictionary<string, Language>();
        public Login(ILocationService locationService, ITranslationService translator, IAuthService authService, IServiceProvider serviceProvider)
        {
            // Set dependencies
            _LocationService = locationService;
            _Translator = translator;
            _AuthService = authService;
            _ServiceProvider = serviceProvider;

            InitializeLanguages();
            InitializeComponent();

            // Set labels to dictionary so we don't have to keep the designer in sync
            cmbLanguage.Items.Clear();
            foreach (string label in _LanguageLabels.Keys)
            {
                cmbLanguage.Items.Add(label);
            }
            cmbLanguage.SelectedIndex = 0;
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            _ServiceProvider = serviceProvider;
        }

        private void InitializeLanguages()
        {
            _LanguageLabels["English"] = Language.English;
            _LanguageLabels["Français"] = Language.French;

            _Translator.AddOrUpdateTranslation("username", Language.French, "nom d'utilisateur");
            _Translator.AddOrUpdateTranslation("password", Language.French, "mot de passe");
            _Translator.AddOrUpdateTranslation("Login credentials are incorrect", Language.French, "Les identifiants de connexion sont incorrects");
            _Translator.AddOrUpdateTranslation("Login failure", Language.French, "Échec de connexion");
            _Translator.AddOrUpdateTranslation("Welcome from", Language.French, "Bienvenue de");
        }

        private void TranslateText()
        {
            // There's instances where this can trigger without having the values from the drop down yet,
            // or where the async UserLocation hasn't been instantiated, at that time we'll just rely on default values
            if (cmbLanguage.SelectedItem == null || _UserLocation == null) return; 


            Language language = _LanguageLabels[cmbLanguage.SelectedItem.ToString()];
            lblWelcome.Text = _UserLocation.WelcomeMessage(language);
            txtUsername.PlaceholderText = _Translator.Translate("username", language);
            txtPassword.PlaceholderText = _Translator.Translate("password", language);
        }

        private async void Login_Load(Object sender, EventArgs e)
        {
            _UserLocation = await _LocationService.GetUserLocationAsync();
            TranslateText();
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            TranslateText();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            bool success = await _AuthService.LoginAsync(txtUsername.Text, txtPassword.Text);
            if (!success)
            {
                string failureMessage = $"{_Translator.Translate("Login credentials are incorrect", _LanguageLabels[cmbLanguage.SelectedItem.ToString()])}.";
                string failureCaption = _Translator.Translate("Login failure", _LanguageLabels[cmbLanguage.SelectedItem.ToString()]);
                MessageBox.Show(failureMessage, failureCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtUsername.Text = String.Empty;
                txtPassword.Text = String.Empty;
            }
            else
            {
                _ServiceProvider.GetRequiredService<Dashboard>().Show();
                Hide();
            }
        }
    }
}
