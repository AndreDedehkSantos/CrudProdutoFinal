using CrudProduto.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness
{
	public class ValidarDadosUsuario 
	{
		public ICollection<string> processar(string nome, string senha1, string senha2)
		{
			ICollection<string> erro = new List<string>();
			if(nome == null)
			{
				erro.Add("Nome de usuário Inválido");
			}
		
			ICollection<string> erroSenha = ValidarSenha(senha1, senha2);
			if (erroSenha.Count != 0)
			{
				foreach(string item in erroSenha)
				{
					erro.Add(item);
				}
			}
			return erro;
		}

		private ICollection<string> ValidarSenha(string senha1, string senha2)
		{
			ICollection<string> erroSenha = new List<string>();
			string validarLetrasMaiusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string validarLetrasMinusculas = "abcdefghijklmnopqrstuvwxyz";
			string validarNumeros = "0123456789";
			string validarSimbolos = "'!@#$%¨&*-_+=/*,.(){}[]?!;:§|/";

			bool vLMai = false;
			bool vLMin = false;
			bool vNum = false;
			bool vSim = false;
			
			foreach (char item in senha1)
			{
				if (validarLetrasMaiusculas.Contains(item))
				{
					vLMai = true;
				}
			}

			foreach (char item in senha1)
			{
				if (validarLetrasMinusculas.Contains(item))
				{
					vLMin = true;
				}
			}

			foreach (char item in senha1)
			{
				if (validarNumeros.Contains(item))
				{
					vNum = true;
				}
			}

			foreach (char item in senha1)
			{
				if (validarSimbolos.Contains(item))
				{
					vSim = true;
				}
			}

			if (senha1.Length < 8 || !vLMai || !vLMin || !vNum || !vSim)

			{
				erroSenha.Add("Senha fraca");
			}
			if (senha1 == null) 
			{
				erroSenha.Add("Senha Inválida");
			}
			if (!senha1.Equals(senha2))
			{
				erroSenha.Add("Senhas diferentes");
			}
			return erroSenha;
		}
	}
}
