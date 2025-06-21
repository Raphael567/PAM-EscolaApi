using EscolaApiAPP.Models;
using EscolaApiAPP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EscolaApiAPP.ViewModels
{
    public class EscolaViewModel : BaseViewModel
    {
        private readonly EscolaService _escolaService;

        public ObservableCollection<Escola> Escolas { get; set; }

        public string CodEscola { get; set; }
        public string NomeEscola { get; set; }
        public string CnpjEscola { get; set; }
        public string CepEscola { get; set; }
        public string NumEnderecoEscola { get; set; }

        private Escola _escolaSelecionada;
        public Escola EscolaSelecionada
        {
            get => _escolaSelecionada;
            set
            {
                if (SetProperty(ref _escolaSelecionada, value) && value != null)
                {
                    CodEscola = value.CodEscola;
                    NomeEscola = value.NomeEscola;
                    CnpjEscola = value.CnpjEscola;
                    CepEscola = value.CepEscola;
                    NumEnderecoEscola = value.NumEnderecoEscola;

                    OnPropertyChanged(nameof(CodEscola));
                    OnPropertyChanged(nameof(NomeEscola));
                    OnPropertyChanged(nameof(CnpjEscola));
                    OnPropertyChanged(nameof(CepEscola));
                    OnPropertyChanged(nameof(NumEnderecoEscola));
                }
            }
        }

        public ICommand CarregarEscolasCommand { get; }
        public ICommand CadastrarEscolaCommand { get; }
        public ICommand AtualizarEscolaCommand { get; }
        public ICommand DeletarEscolaCommand { get; }

        public EscolaViewModel()
        {
            _escolaService = new EscolaService();
            Escolas = new ObservableCollection<Escola>();

            CarregarEscolasCommand = new Command(async () => await CarregarEscolas());
            CadastrarEscolaCommand = new Command<Escola>(async (escola) => await CadastrarEscola());
            AtualizarEscolaCommand = new Command<Escola>(async (escola) => await AtualizarEscola());
            DeletarEscolaCommand = new Command<Escola>(async (escola) => await DeletarEscola());
        }

        public async Task CarregarEscolas()
        {
            try
            {
                Escolas.Clear();
                var lista = await _escolaService.GetAllAsync();
                foreach (var e in lista)
                    Escolas.Add(e);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Falha ao carregar escolas: {ex.Message}", "OK");
            }
        }

        public async Task CadastrarEscola()
        {
            try
            {
                var escola = new Escola
                {
                    CodEscola = CodEscola,
                    NomeEscola = NomeEscola,
                    CnpjEscola = CnpjEscola,
                    CepEscola = CepEscola,
                    NumEnderecoEscola = NumEnderecoEscola
                };
                
                if (await _escolaService.CadastrarAsync(escola))
                {
                    await CarregarEscolas();
                    await App.Current.MainPage.DisplayAlert("Sucesso", "Escola cadastrada com sucesso", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Falha ao cadastrar escola: {ex.Message}", "OK");
            }
        }

        public async Task AtualizarEscola()
        {
            try
            {
                var escola = new Escola
                {
                    CodEscola = CodEscola,
                    NomeEscola = NomeEscola,
                    CnpjEscola = CnpjEscola,
                    CepEscola = CepEscola,
                    NumEnderecoEscola = NumEnderecoEscola
                };

                await _escolaService.AtualizarAsync(escola);

                await CarregarEscolas();
                await App.Current.MainPage.DisplayAlert("Sucesso", "Escola atualizada!", "OK");
                EscolaSelecionada = null;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Falha ao atualizar escola: {ex.Message}", "OK");
            }
        }

        public async Task DeletarEscola()
        {
            try
            {
                if (EscolaSelecionada != null)
                {
                    await _escolaService.DeletarAsync(EscolaSelecionada.CodEscola);
                    await CarregarEscolas();
                    await App.Current.MainPage.DisplayAlert("Sucesso ao deletar escola", "Escola Deletada!", "OK");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Aviso", "Selecione uma escola primeiro.", "OK");

                EscolaSelecionada = null;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Falha ao deletar escola: {ex.Message}", "OK");
            }
        }
    }
}
