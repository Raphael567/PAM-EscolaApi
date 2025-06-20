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

        private Escola _escolaSelecionada;
        public Escola EscolaSelecionada
        {
            get => _escolaSelecionada;
            set
            {
                if (SetProperty(ref _escolaSelecionada, value) && value != null)
                {
                    Shell.Current.GoToAsync($"cadastroEscolaView?codEscola={value.CodEscola}");

                    EscolaSelecionada = null;
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
            CadastrarEscolaCommand = new Command<Escola>(async (escola) => await CadastrarEscola(escola));
            AtualizarEscolaCommand = new Command<Escola>(async (escola) => await AtualizarEscola(escola));
            DeletarEscolaCommand = new Command<Escola>(async (escola) => await DeletarEscola(escola));
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

        public async Task CadastrarEscola(Escola escola)
        {
            try
            {
                if (await _escolaService.CadastrarAsync(escola))
                {
                    Escolas.Add(escola);
                    await App.Current.MainPage.DisplayAlert("Sucesso", "Escola cadastrada!", "OK");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Erro", "Falha ao cadastrar escola.", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Falha ao cadastrar escola: {ex.Message}", "OK");
            }
        }

        public async Task AtualizarEscola(Escola escola)
        {
            try
            {
                if (await _escolaService.AtualizarAsync(escola))
                {
                    await App.Current.MainPage.DisplayAlert("Sucesso", "Escola atualizada!", "OK");
                    await CarregarEscolas();
                }
                else
                    await App.Current.MainPage.DisplayAlert("Erro", "Falha ao atualizar escola.", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Falha ao atualizar escola: {ex.Message}", "OK");
            }
        }

        public async Task DeletarEscola(Escola escola)
        {
            try
            {
                bool confirm = await App.Current.MainPage.DisplayAlert("Confirmação", $"Deseja deletar {escola.NomeEscola}?", "Sim", "Não");
                if (!confirm) return;

                if (await _escolaService.DeletarAsync(escola.CodEscola))
                {
                    Escolas.Remove(escola);
                    await App.Current.MainPage.DisplayAlert("Sucesso", "Escola deletada!", "OK");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Erro", "Falha ao deletar escola.", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Falha ao deletar escola: {ex.Message}", "OK");
            }
        }
    }
}
