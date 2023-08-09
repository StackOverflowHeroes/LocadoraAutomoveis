﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public class ValidadorAluguel : AbstractValidator<Aluguel>, IValidadorAluguel
    {
        public ValidadorAluguel()
        {
            RuleFor(a => a.Funcionario)
                .NotNull().WithMessage("'Funcionário' é obrigatório.");

            RuleFor(a => a.Cliente)
                .NotNull().WithMessage("'Cliente' é obrigatório.");

            RuleFor(a => a.GrupoAutomovel)
                .NotNull().WithMessage("'Grupo de Automóveis' é obrigatória.");

            RuleFor(a => a.PlanoCobranca)
                .NotNull().WithMessage("'Plano de Cobrança' é obrigatório.");

            //RuleFor(a => a.Condutor)
            //    .NotNull().WithMessage("'Condutor' é obrigatório.");

            //RuleFor(a => a.Automovel)
            //    .NotNull().WithMessage("'Automóvel' é obrigatório.");

            RuleFor(a => a.Cupom)
                .NotNull().WithMessage("'Cupom' é obrigatório.");

            RuleFor(a => a.TaxaServicos)
                .Must(lista => lista != null && lista.Count > 0).WithMessage("'Lista de Taxas e Serviços' não pode ser vazia.");

            RuleFor(a => a.DataLocacao)
                .LessThan(a => a.DataPrevisaoRetorno).WithMessage("'Data de Locação' deve ser menor que a 'Data Prevista de Retorno'.");

            RuleFor(a => a.ValorTotal)
                .GreaterThanOrEqualTo(0).WithMessage("'Valor Total' não pode ser menor que zero.");

            RuleFor(a => a.DataDevolucao)
                .GreaterThan(a => a.DataLocacao).WithMessage("'Data de Devolução' deve ser maior que a 'Data de Locação'.");

            RuleFor(a => a.QuilometrosRodados)
                .GreaterThanOrEqualTo(0).WithMessage("'Quilometros Rodados' não pode ser menor que zero.");

            RuleFor(a => a.CombustivelRestante)
                .IsInEnum().WithMessage("'Combustível Restante' inválido.");
        }

        public bool ValidarAluguelConcluido(Aluguel aluguelValidar)
        {
            return aluguelValidar.Concluido;
        }
    }
}
