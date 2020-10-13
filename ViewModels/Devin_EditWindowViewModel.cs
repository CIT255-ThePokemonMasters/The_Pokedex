using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using The_Pokedex.BusinessLayer;
using The_Pokedex.Models;
using The_Pokedex.UtilityClass;

namespace The_Pokedex.ViewModels
{
    class Devin_EditWindowViewModel : ObservableObject
    {
        #region Commands

        public ICommand ButtonSaveCommand
        {
            get
            {
                return new RelayCommand(new Action<object>(EditPokemon));
            }
        }


        public ICommand ButtonCancelCommand
        {
            get
            {
                return new RelayCommand(new Action<object>(CancelPokemon));
            }
        }

        public ICommand AddImageCommand
        {
            get
            {
                return new RelayCommand(new Action<object>(AddImage));
            }
        }

        #endregion

        #region Fields

        private PokemonBusiness _pokemonBusiness;
        private PokemonOperation _pokemonOperation;

        private string _imageSource;
        private string _userPokemonImage;

        #region type bools

        //type bools for checkboxes
        private bool _fireIsChecked;
        private bool _waterIsChecked;
        private bool _grassIsChecked;
        private bool _normalIsChecked;
        private bool _fightingIsChecked;
        private bool _electricIsChecked;
        private bool _flyingIsChecked;
        private bool _poisonIsChecked;
        private bool _groundIsChecked;
        private bool _rockIsChecked;
        private bool _psychicIsChecked;
        private bool _iceIsChecked;
        private bool _dragonIsChecked;
        private bool _ghostIsChecked;
        private bool _darkIsChecked;
        private bool _steelIsChecked;
        private bool _fairyIsChecked;
        private bool _bugIsChecked;

        #endregion

        #region weakness bools

        //weakness bool for checkboxes
        private bool _weaknessToFireIsChecked;
        private bool _weaknessToWaterIsChecked;
        private bool _weaknessToGrassIsChecked;
        private bool _weaknessTonormalIsChecked;
        private bool _weaknessTofightingIsChecked;
        private bool _weaknessToelectricIsChecked;
        private bool _weaknessToflyingIsChecked;
        private bool _weaknessTopoisonIsChecked;
        private bool _weaknessTogroundIsChecked;
        private bool _weaknessTorockIsChecked;
        private bool _weaknessTopsychicIsChecked;
        private bool _weaknessToiceIsChecked;
        private bool _weaknessTodragonIsChecked;
        private bool _weaknessToghostIsChecked;
        private bool _weaknessTodarkIsChecked;
        private bool _weaknessTosteelIsChecked;
        private bool _weaknessTofairyIsChecked;
        private bool _weaknessTobugIsChecked;

        #endregion

        #endregion

        #region Properties

        public Pokemon UserPokemon { get; set; }

        #region Type bools

        public bool FireIsChecked
        {
            get { return _fireIsChecked; }
            set
            {
                _fireIsChecked = value;
                OnPropertyChanged(nameof(FireIsChecked));
            }
        }

        public bool WaterIsChecked
        {
            get { return _waterIsChecked; }
            set
            {
                _waterIsChecked = value;
                OnPropertyChanged(nameof(WaterIsChecked));
            }
        }

        public bool GrassIsChecked
        {
            get { return _grassIsChecked; }
            set
            {
                _grassIsChecked = value;
                OnPropertyChanged(nameof(GrassIsChecked));
            }
        }

        public bool NormalIsChecked
        {
            get { return _normalIsChecked; }
            set
            {
                _normalIsChecked = value;
                OnPropertyChanged(nameof(NormalIsChecked));
            }
        }

        public bool FightingIsChecked
        {
            get { return _fightingIsChecked; }
            set
            {
                _fightingIsChecked = value;
                OnPropertyChanged(nameof(FightingIsChecked));
            }
        }

        public bool ElectricIsChecked
        {
            get { return _electricIsChecked; }
            set
            {
                _electricIsChecked = value;
                OnPropertyChanged(nameof(ElectricIsChecked));
            }
        }

        public bool FlyingIsChecked
        {
            get { return _flyingIsChecked; }
            set
            {
                _flyingIsChecked = value;
                OnPropertyChanged(nameof(FlyingIsChecked));
            }
        }

        public bool PoisonIsChecked
        {
            get { return _poisonIsChecked; }
            set
            {
                _poisonIsChecked = value;
                OnPropertyChanged(nameof(PoisonIsChecked));
            }
        }

        public bool GroundIsChecked
        {
            get { return _groundIsChecked; }
            set
            {
                _groundIsChecked = value;
                OnPropertyChanged(nameof(GroundIsChecked));
            }
        }

        public bool RockIsChecked
        {
            get { return _rockIsChecked; }
            set
            {
                _rockIsChecked = value;
                OnPropertyChanged(nameof(RockIsChecked));
            }
        }

        public bool PsychicIsChecked
        {
            get { return _psychicIsChecked; }
            set
            {
                _psychicIsChecked = value;
                OnPropertyChanged(nameof(PsychicIsChecked));
            }
        }

        public bool IceIsChecked
        {
            get { return _iceIsChecked; }
            set
            {
                _iceIsChecked = value;
                OnPropertyChanged(nameof(IceIsChecked));
            }
        }

        public bool DragonIsChecked
        {
            get { return _dragonIsChecked; }
            set
            {
                _dragonIsChecked = value;
                OnPropertyChanged(nameof(DragonIsChecked));
            }
        }

        public bool GhostIsChecked
        {
            get { return _ghostIsChecked; }
            set
            {
                _ghostIsChecked = value;
                OnPropertyChanged(nameof(GhostIsChecked));
            }
        }

        public bool DarkIsChecked
        {
            get { return _darkIsChecked; }
            set
            {
                _darkIsChecked = value;
                OnPropertyChanged(nameof(DarkIsChecked));
            }
        }

        public bool SteelIsChecked
        {
            get { return _steelIsChecked; }
            set
            {
                _steelIsChecked = value;
                OnPropertyChanged(nameof(SteelIsChecked));
            }
        }

        public bool FairyIsChecked
        {
            get { return _fairyIsChecked; }
            set
            {
                _fairyIsChecked = value;
                OnPropertyChanged(nameof(FairyIsChecked));
            }
        }

        public bool BugIsChecked
        {
            get { return _bugIsChecked; }
            set
            {
                _bugIsChecked = value;
                OnPropertyChanged(nameof(BugIsChecked));
            }
        }

        #endregion

        #region Weakness Bools

        public bool WeaknessToFireIsChecked
        {
            get { return _weaknessToFireIsChecked; }
            set
            {
                _weaknessToFireIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToFireIsChecked));
            }
        }

        public bool WeaknessToWaterIsChecked
        {
            get { return _weaknessToWaterIsChecked; }
            set
            {
                _weaknessToWaterIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToWaterIsChecked));
            }
        }

        public bool WeaknessToGrassIsChecked
        {
            get { return _weaknessToGrassIsChecked; }
            set
            {
                _weaknessToGrassIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToGrassIsChecked));
            }
        }

        public bool WeaknessToNormalIsChecked
        {
            get { return _weaknessTonormalIsChecked; }
            set
            {
                _weaknessTonormalIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToNormalIsChecked));
            }
        }

        public bool WeaknessToFightingIsChecked
        {
            get { return _weaknessTofightingIsChecked; }
            set
            {
                _weaknessTofightingIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToFightingIsChecked));
            }
        }

        public bool WeaknessToElectricIsChecked
        {
            get { return _weaknessToelectricIsChecked; }
            set
            {
                _weaknessToelectricIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToElectricIsChecked));
            }
        }

        public bool WeaknessToFlyingIsChecked
        {
            get { return _weaknessToflyingIsChecked; }
            set
            {
                _weaknessToflyingIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToFlyingIsChecked));
            }
        }

        public bool WeaknessToPoisonIsChecked
        {
            get { return _weaknessTopoisonIsChecked; }
            set
            {
                _weaknessTopoisonIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToPoisonIsChecked));
            }
        }

        public bool WeaknessToGroundIsChecked
        {
            get { return _weaknessTogroundIsChecked; }
            set
            {
                _weaknessTogroundIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToGroundIsChecked));
            }
        }

        public bool WeaknessToRockIsChecked
        {
            get { return _weaknessTorockIsChecked; }
            set
            {
                _weaknessTorockIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToRockIsChecked));
            }
        }

        public bool WeaknessToPsychicIsChecked
        {
            get { return _weaknessTopsychicIsChecked; }
            set
            {
                _weaknessTopsychicIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToPsychicIsChecked));
            }
        }

        public bool WeaknessToIceIsChecked
        {
            get { return _weaknessToiceIsChecked; }
            set
            {
                _weaknessToiceIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToIceIsChecked));
            }
        }

        public bool WeaknessToDragonIsChecked
        {
            get { return _weaknessTodragonIsChecked; }
            set
            {
                _weaknessTodragonIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToDragonIsChecked));
            }
        }

        public bool WeaknessToGhostIsChecked
        {
            get { return _weaknessToghostIsChecked; }
            set
            {
                _weaknessToghostIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToGhostIsChecked));
            }
        }

        public bool WeaknessToDarkIsChecked
        {
            get { return _weaknessTodarkIsChecked; }
            set
            {
                _weaknessTodarkIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToDarkIsChecked));
            }
        }

        public bool WeaknessToSteelIsChecked
        {
            get { return _weaknessTosteelIsChecked; }
            set
            {
                _weaknessTosteelIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToSteelIsChecked));
            }
        }

        public bool WeaknessToFairyIsChecked
        {
            get { return _weaknessTofairyIsChecked; }
            set
            {
                _weaknessTofairyIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToFairyIsChecked));
            }
        }

        public bool WeaknessToBugIsChecked
        {
            get { return _weaknessTobugIsChecked; }
            set
            {
                _weaknessTobugIsChecked = value;
                OnPropertyChanged(nameof(WeaknessToBugIsChecked));
            }
        }

        #endregion

        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        public string UserPokemonImage
        {
            get { return _userPokemonImage; }
            set
            {
                _userPokemonImage = value;
                OnPropertyChanged(nameof(UserPokemonImage));
            }
        }

        #endregion

        #region Constructors

        public Devin_EditWindowViewModel(PokemonOperation pokemonOperation)
        {
            UserPokemon = pokemonOperation.pokemon;
            _pokemonOperation = pokemonOperation;
            _pokemonBusiness = new PokemonBusiness();
            ImageSource = UserPokemon.ImageFilePath;

            DetermineCurrentType();
            DetermineCurrentWeakness();
        }

        #endregion

        #region Methods

        /// <summary>
        /// edit the pokemon
        /// </summary>
        private void EditPokemon(object obj)
        {
            UserPokemon.PokemonType = ConvertTypeChecksIntoType();
            UserPokemon.Weakness = ConvertWeaknessChecksIntoType();
            _pokemonOperation.Status = PokemonOperation.OperationStatus.OKAY;
            UserPokemon.ImageFileName = UserPokemonImage;

            if (UserPokemon.PokemonType.Count == 0)
            {
                UserPokemon.PokemonType.Add(Pokemon.Type.NONE);
            }

            if (UserPokemon.Weakness.Count == 0)
            {
                UserPokemon.Weakness.Add(Pokemon.Type.NONE);
            }

            if (String.IsNullOrEmpty(UserPokemon.Name))
            {
                UserPokemon.Name = "Unknown";
            }

            if (String.IsNullOrEmpty(UserPokemon.Abilities))
            {
                UserPokemon.Abilities = "N/A";
            }

            if (String.IsNullOrEmpty(UserPokemon.Description))
            {
                UserPokemon.Description = "N/A";
            }

            if (String.IsNullOrEmpty(UserPokemon.Category))
            {
                UserPokemon.Category = "N/A";
            }

            if (String.IsNullOrEmpty(UserPokemon.ImageFileName))
            {
                UserPokemon.ImageFileName = "defaultImage.png";
            }

            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"C:\NMC Classes\CIT255\The_Pokedex\Media\coinSound.wav"));
            mediaPlayer.Play();

            if (obj is System.Windows.Window)
            {
                (obj as System.Windows.Window).Close();
            }
        }

        /// <summary>
        /// cancel the edit
        /// </summary>
        private void CancelPokemon(object obj)
        {
            _pokemonOperation.Status = PokemonOperation.OperationStatus.CANCEL;

            if (obj is System.Windows.Window)
            {
                (obj as System.Windows.Window).Close();
            }
        }

        /// <summary>
        /// checks which checkboxes are checked and adds the appropriate type
        /// </summary>
        private List<Pokemon.Type> ConvertTypeChecksIntoType()
        {
            List<Pokemon.Type> types = new List<Pokemon.Type>();

            if (FireIsChecked == true)
            {
                types.Add(Pokemon.Type.FIRE);
            }
            if (WaterIsChecked == true)
            {
                types.Add(Pokemon.Type.WATER);
            }
            if (GrassIsChecked == true)
            {
                types.Add(Pokemon.Type.GRASS);
            }
            if (NormalIsChecked == true)
            {
                types.Add(Pokemon.Type.NORMAL);
            }
            if (FightingIsChecked == true)
            {
                types.Add(Pokemon.Type.FIGHTING);
            }
            if (ElectricIsChecked == true)
            {
                types.Add(Pokemon.Type.ELECTRIC);
            }
            if (FlyingIsChecked == true)
            {
                types.Add(Pokemon.Type.FLYING);
            }
            if (PoisonIsChecked == true)
            {
                types.Add(Pokemon.Type.POISON);
            }
            if (GroundIsChecked == true)
            {
                types.Add(Pokemon.Type.GROUND);
            }
            if (RockIsChecked == true)
            {
                types.Add(Pokemon.Type.ROCK);
            }
            if (PsychicIsChecked == true)
            {
                types.Add(Pokemon.Type.PSYCHIC);
            }
            if (IceIsChecked == true)
            {
                types.Add(Pokemon.Type.ICE);
            }
            if (DragonIsChecked == true)
            {
                types.Add(Pokemon.Type.DRAGON);
            }
            if (GhostIsChecked == true)
            {
                types.Add(Pokemon.Type.GHOST);
            }
            if (DarkIsChecked == true)
            {
                types.Add(Pokemon.Type.DARK);
            }
            if (SteelIsChecked == true)
            {
                types.Add(Pokemon.Type.STEEL);
            }
            if (FairyIsChecked == true)
            {
                types.Add(Pokemon.Type.FAIRY);
            }
            if (BugIsChecked == true)
            {
                types.Add(Pokemon.Type.BUG);
            }
            return types;
        }

        /// <summary>
        /// checks which checkboxes are checked and adds the appropriate weakness
        /// </summary>
        private List<Pokemon.Type> ConvertWeaknessChecksIntoType()
        {
            List<Pokemon.Type> weaknessTypes = new List<Pokemon.Type>();

            if (WeaknessToFireIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.FIRE);
            }
            if (WeaknessToWaterIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.WATER);
            }
            if (WeaknessToGrassIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.GRASS);
            }
            if (WeaknessToNormalIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.NORMAL);
            }
            if (WeaknessToFightingIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.FIGHTING);
            }
            if (WeaknessToElectricIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.ELECTRIC);
            }
            if (WeaknessToFlyingIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.FLYING);
            }
            if (WeaknessToPoisonIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.POISON);
            }
            if (WeaknessToGroundIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.GROUND);
            }
            if (WeaknessToRockIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.ROCK);
            }
            if (WeaknessToPsychicIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.PSYCHIC);
            }
            if (WeaknessToIceIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.ICE);
            }
            if (WeaknessToDragonIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.DRAGON);
            }
            if (WeaknessToGhostIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.GHOST);
            }
            if (WeaknessToDarkIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.DARK);
            }
            if (WeaknessToSteelIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.STEEL);
            }
            if (WeaknessToFairyIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.FAIRY);
            }
            if (WeaknessToBugIsChecked == true)
            {
                weaknessTypes.Add(Pokemon.Type.BUG);
            }
            return weaknessTypes;
        }


        /// <summary>
        /// gets current pokemon's type and checks the appropriate checkbox
        /// </summary>
        private void DetermineCurrentType()
        {
            if (UserPokemon != null)
            {
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.BUG))
                {
                    BugIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.DARK))
                {
                    DarkIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.DRAGON))
                {
                    DragonIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.ELECTRIC))
                {
                    ElectricIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.FAIRY))
                {
                    FairyIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.FIGHTING))
                {
                    FightingIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.FIRE))
                {
                    FireIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.FLYING))
                {
                    FlyingIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.GHOST))
                {
                    GhostIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.GRASS))
                {
                    GrassIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.GROUND))
                {
                    GroundIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.ICE))
                {
                    IceIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.NORMAL))
                {
                    NormalIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.POISON))
                {
                    PoisonIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.PSYCHIC))
                {
                    PsychicIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.ROCK))
                {
                    RockIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.STEEL))
                {
                    SteelIsChecked = true;
                }
                if (UserPokemon.PokemonType.Contains(Pokemon.Type.WATER))
                {
                    WaterIsChecked = true;
                }
            }

        }

        /// <summary>
        /// gets current pokemon's weakness and checks the appropriate checkbox
        /// </summary>
        private void DetermineCurrentWeakness()
        {
            if (UserPokemon != null)
            {
                if (UserPokemon.Weakness.Contains(Pokemon.Type.BUG))
                {
                    WeaknessToBugIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.DARK))
                {
                    WeaknessToDarkIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.DRAGON))
                {
                    WeaknessToDragonIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.ELECTRIC))
                {
                    WeaknessToElectricIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.FAIRY))
                {
                    WeaknessToFairyIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.FIGHTING))
                {
                    WeaknessToFightingIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.FIRE))
                {
                    WeaknessToFireIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.FLYING))
                {
                    WeaknessToFlyingIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.GHOST))
                {
                    WeaknessToGhostIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.GRASS))
                {
                    WeaknessToGrassIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.GROUND))
                {
                    WeaknessToGroundIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.ICE))
                {
                    WeaknessToIceIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.NORMAL))
                {
                    WeaknessToNormalIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.POISON))
                {
                    WeaknessToPoisonIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.PSYCHIC))
                {
                    WeaknessToPsychicIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.ROCK))
                {
                    WeaknessToRockIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.STEEL))
                {
                    WeaknessToSteelIsChecked = true;
                }
                if (UserPokemon.Weakness.Contains(Pokemon.Type.WATER))
                {
                    WeaknessToWaterIsChecked = true;
                }
            }
        }

        /// <summary>
        /// allows user to select image from file
        /// </summary>
        private void AddImage(object image)
        {
            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Images\";
            string useablePath = @"C:\NMC Classes\CIT255\The_Pokedex\Images\";
            //string useablePath = @"C:\Users\Khyr\source\repos\The_Pokedex\";

            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";
                if (op.ShowDialog() == true)
                {
                    string iName = op.SafeFileName;
                    string filePath = op.FileName;
                    if (!File.Exists(useablePath + op.SafeFileName))
                    {
                        File.Copy(filePath, appPath + iName);
                        File.Copy(filePath, useablePath + iName);
                        ImageSource = new BitmapImage(new Uri(op.FileName)).ToString();
                        UserPokemonImage = op.SafeFileName;
                    }
                    else
                    {
                        ImageSource = new BitmapImage(new Uri(op.FileName)).ToString();
                        UserPokemonImage = op.SafeFileName;
                    }
                }
            }
            catch (Exception e)
            {
                string m = e.Message;
                throw;
            }

        }

        #endregion
    }
}
