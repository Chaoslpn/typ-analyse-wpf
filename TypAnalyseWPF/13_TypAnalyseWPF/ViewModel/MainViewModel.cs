using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Documents;

namespace TypAnalyseWPF
{
    public class MainViewModel : BaseModel
    {
        private bool _specialNameChecked;
        public bool SpecialNameChecked
        {
            get { return _specialNameChecked; }
            set 
            { 
                _specialNameChecked = value;
                OnPropertyChanged("SpecialNameChecked");
                FillLists();
            }
        }
        private bool _staticChecked;
        public bool StaticChecked
        {
            get { return _staticChecked; }
            set 
            { 
                _staticChecked = value;
                OnPropertyChanged("StaticChecked");
                FillLists();
            }
        }
        private bool _vererbungChecked;
        public bool VererbungChecked
        {
            get { return _vererbungChecked; }
            set 
            { 
                _vererbungChecked = value;
                OnPropertyChanged("VererbungChecked");
                FillLists();
            }
        }
        private BindingFlags _bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic;
        public BindingFlags BindingFlags 
        {
            get { return _bindingFlags; }
            set { _bindingFlags = value; }
        }
        private Type _selClass;
        public Type SelType
        {
            get 
            { 
                return _selClass; 
            }
            set 
            { 
                _selClass = value;
                OnPropertyChanged("SelType");
                FillLists();
            }
        }
        private ObservableCollection<string> _lstFields = new ObservableCollection<string>();
        public ObservableCollection<string> LstFields
        {
            get
            {
                return _lstFields;
            }
            set
            {
                _lstFields = value;
                OnPropertyChanged("LstFields");
            }
        }
        private ObservableCollection<string> _lstProperties = new ObservableCollection<string>();
        public ObservableCollection<string> LstProperties
        {
            get { return _lstProperties; }
            set
            {
                _lstProperties = value;
                OnPropertyChanged("LstProperties");
            }
        }
        private ObservableCollection<string> _lstConstructors = new ObservableCollection<string>();
        public ObservableCollection<string> LstConstructors
        {
            get { return _lstConstructors; }
            set
            {
                _lstConstructors = value;
                OnPropertyChanged("LstConstructors");
            }
        }
        private ObservableCollection<string> _lstMethods = new ObservableCollection<string>();
        public ObservableCollection<string> LstMethods
        {
            get { return _lstMethods; }
            set
            {
                _lstMethods = value;
                OnPropertyChanged("LstMethods");
            }
        }
        private ObservableCollection<Type> _lstTypes = new ObservableCollection<Type>();
        public ObservableCollection<Type> LstTypes
        {
            get { return _lstTypes; }
            set 
            { 
                _lstTypes = value;
                OnPropertyChanged("LstTypes");
            }
        }

        public MainViewModel()
        {
            FillListTypes();
        }

        public void FillLists()
        {
            BuildBindingFlags();
            FillListFields();
            FillListProperties();
            FillListMethods();
            FillListConstructors();
        }

        private void FillListConstructors()
        {
            this.LstConstructors.Clear();

            ConstructorInfo[] kons = this.SelType.GetConstructors(this.BindingFlags);
            foreach (ConstructorInfo kon in kons)
            {
                string para = "";

                foreach (ParameterInfo par in kon.GetParameters())
                    para += $"{par.ParameterType.Name} {par.Name}, ";

                if(para.Length > 1) 
                    para = para.Remove(para.Length - 2);

                this.LstConstructors.Add($"{this.SelType.Name}({para})");
            }
        }

        private void FillListMethods()
        {
            this.LstMethods.Clear();

            MethodInfo[] method = this.SelType.GetMethods(this.BindingFlags);
            foreach (MethodInfo metho in method)
            {
                string text = "", sichtbarkeit = "";
                if (metho.IsSpecialName && this.SpecialNameChecked)
                    continue;

                if (metho.IsPublic)
                    sichtbarkeit = "public";
                else if (metho.IsPrivate)
                    sichtbarkeit = "private";
                else if (metho.IsFamily)
                    sichtbarkeit = "protected";
                if (metho.IsAssembly)
                    sichtbarkeit = "internal";
                if (metho.IsStatic)
                    sichtbarkeit += " static";

                foreach (ParameterInfo par in metho.GetParameters())
                    text += $"{par.ParameterType.Name} {par.Name}, ";

                if(text.Length > 1)
                    text = text.Remove(text.Length - 2);
                
                this.LstMethods.Add($"{sichtbarkeit} {metho.ReturnType.Name} {metho.Name}({text})");
            }
        }

        private void FillListProperties()
        {
            this.LstProperties.Clear();

            PropertyInfo[] property = this.SelType.GetProperties(this.BindingFlags);
            foreach (PropertyInfo propertyInfo in property)
            {
                string text = $"public {propertyInfo.PropertyType.Name} {propertyInfo.Name} ";

                // Sichtbarkeiten der Accessoren prüfen
                if (propertyInfo.SetMethod == null)
                    text += "{get;}";
                else if (propertyInfo.SetMethod.IsPublic && propertyInfo.GetMethod.IsPublic)
                    text += "{get; set;}";
                else
                    text += "{get; private set;}";

                this.LstProperties.Add(text);
            }
        }

        private void FillListFields()
        {
            this.LstFields.Clear();

            FieldInfo[] field = this.SelType.GetFields(this.BindingFlags);
            foreach (FieldInfo fieldInfo in field)
            {
                string sichtbarkeit = "", text;
                if (fieldInfo.IsPublic)
                    sichtbarkeit = "public";
                else if (fieldInfo.IsPrivate)
                    sichtbarkeit = "private";
                else if (fieldInfo.IsFamily)
                    sichtbarkeit = "protected";
                if (fieldInfo.IsAssembly)
                    sichtbarkeit = "internal";
                if (fieldInfo.IsStatic)
                    sichtbarkeit += " static";

                text = $"{sichtbarkeit} {fieldInfo.FieldType.Name} {fieldInfo.Name}";
                this.LstFields.Add(text);
            }
        }

        private void FillListTypes()
        {
            Type[] myTypes = Assembly.GetEntryAssembly().GetTypes();
            this.LstTypes = new ObservableCollection<Type>(new List<Type>(myTypes));
            // Alle von diesem Projekt referenzierten DLLs holen
            AssemblyName[] an = Assembly.GetEntryAssembly().GetReferencedAssemblies();
            foreach(AssemblyName assembly in an)
            {
                // DLL laden und Klassen (Typen) auslesen
                Assembly a = Assembly.Load(assembly);
                Type[] lsttypes = a.GetExportedTypes();
                foreach(Type t in lsttypes)
                {
                    this.LstTypes.Add(t);
                }
            }
        }

        private void BuildBindingFlags()
        {
            this.BindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic;
            if (this.StaticChecked)
                this.BindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            if (this.VererbungChecked)
                this.BindingFlags |= BindingFlags.DeclaredOnly;
        }
    }
}
