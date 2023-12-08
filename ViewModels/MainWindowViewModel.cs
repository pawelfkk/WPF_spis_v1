using Firma.Helpers;
using Firma.ViewResources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Firma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        //Contains collection of command, that appears on side bar and collection of tabs
        #region Komendy menu i paska narzedzi

        /// <summary>
        /// This command will be use in top menu and toolbar
        /// </summary>
        public ICommand NewItemCommand
        {
            get
            {
                return new BaseCommand(() => CreateView(new NewItemViewModel()));
            }
        }
        public ICommand ItemsCommand
        {
            get
            {
                return new BaseCommand(showAllItems);
            }
        }
        public ICommand NewInvoiceCommand
        {
            get
            {
                return new BaseCommand(() => CreateView(new NewInvoiceViewModel()));
            }
        }
        public ICommand PZCommand
        {
            get
            {
                return new BaseCommand(() => CreateView(new PZViewModel()));
            }
        }
        public ICommand WZCommand
        {
            get
            {
                return new BaseCommand(() => CreateView(new WZViewModel()));
            }
        }
        public ICommand InvoicesCommand
        {
            get
            {
                return new BaseCommand(ShowAllInvoices);
            }
        }
        public ICommand NewCustomerCommand
        {
            get
            {
                return new BaseCommand(() => CreateView(new NewCustomerViewModel()));
            }
        }
        #endregion
        public ICommand ShowAuthorCommand
        {
            get
            {
                return new BaseCommand(ShowAuthorInfo);
            }
        }
        private void ShowAuthorInfo()
        {
            MessageBox.Show("Autor: Paweł Fiuk\nEmail: pfiuk@student.wsb-nlu.edu.pl", "Informacje o autorze", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public MainWindowViewModel()
        {
            Commands = new(CreateCommands());
            Workspaces = new();
            Workspaces.CollectionChanged += OnWorkspacesChanged;
        }

        #region Buttons in side bar

        /// <summary>
        /// This is collection of commands in side bar
        /// </summary>
        public ReadOnlyCollection<CommandViewModel> Commands { get; set; }

        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
                new CommandViewModel("Produkty",new BaseCommand(showAllItems)), //in here we create button with name Items that open all items' tab
                new CommandViewModel("Nowy produkt",new BaseCommand(()=>CreateView(new NewItemViewModel()))),
                new CommandViewModel("Nowa faktura",new BaseCommand(()=>CreateView(new NewInvoiceViewModel()))),
                new CommandViewModel("Faktury",new BaseCommand(ShowAllInvoices)),
                new CommandViewModel(GlobalResources.NowyKontrahent, new BaseCommand(() => CreateView(new NewCustomerViewModel()))),
                new CommandViewModel(GlobalResources.WZ, new BaseCommand(() => CreateView(new WZViewModel()))),
                new CommandViewModel(GlobalResources.PZ, new BaseCommand(() => CreateView(new PZViewModel())))
            };
        }
        #endregion

        #region Zakładki
        public ObservableCollection<WorkspaceViewModel> Workspaces { get; set; }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion

        #region Funkcje pomocnicze
        private void CreateView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }
        private void ShowAllInvoices()
        {
            AllInvoicesViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllInvoicesViewModel) as AllInvoicesViewModel;
            if (workspace == null)
            {
                workspace = new AllInvoicesViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        /// <summary>
        /// this is method that creates new items tab
        /// each time it checks if such tab is opened. If yes - opens it, if no - creates new one
        /// </summary>
        private void showAllItems()
        {
            AllItemsViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is AllItemsViewModel) as AllItemsViewModel;
            if (workspace == null)
            {
                workspace = new AllItemsViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        public ICommand ExitCommand => new RelayCommand(() => Application.Current.Shutdown());

    }

public class RelayCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;

    public RelayCommand(Action execute, Func<bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

    public void Execute(object parameter) => _execute();
}
        #endregion
    }

