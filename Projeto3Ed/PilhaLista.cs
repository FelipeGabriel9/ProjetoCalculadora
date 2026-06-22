using System;

namespace Calculadora.Core
{
    /// <summary>
    /// Pilha implementada com lista encadeada simples.
    /// Todas as operações principais têm custo O(1).
    /// </summary>
    public sealed class PilhaLista<T> : IPilha<T>
    {
        // ── Estado interno ────────────────────────────────────────────── //
        private No<T> _topo;
        private int _quantidade;

        // ── Propriedades ──────────────────────────────────────────────── //
        public bool EstaVazia => _topo is null;
        public int Tamanho => _quantidade;

        // ── Operações ─────────────────────────────────────────────────── //

        /// <inheritdoc/>
        public void Empilhar(T elemento)
        {
            _topo = new No<T>(elemento, _topo);
            _quantidade++;
        }

        /// <inheritdoc/>
        /// <exception cref="InvalidOperationException">Pilha vazia.</exception>
        public T Desempilhar()
        {
            if (EstaVazia)
                throw new InvalidOperationException("Operação inválida: pilha está vazia.");

            T valor = _topo.Valor;
            _topo = _topo.Proximo;
            _quantidade--;
            return valor;
        }

        /// <inheritdoc/>
        /// <exception cref="InvalidOperationException">Pilha vazia.</exception>
        public T OTopo()
        {
            if (EstaVazia)
                throw new InvalidOperationException("Operação inválida: pilha está vazia.");

            return _topo.Valor;
        }
    }
}
