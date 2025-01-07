using System;
using System.Diagnostics;

List<Produto> produtos = new List<Produto>();
while (true)
{
  Console.WriteLine(@"
 ___ ___    ___  __  _   ____  ___    ____  ____       ___     ___       _____    ___ 
|   |   |  /  _]|  |/ ] /    ||   \  |    ||    \     |   \   /   \     |     |  /  _]
| _   _ | /  [_ |  ' / |  o  ||    \  |  | |  _  |    |    \ |     |    |__/  | /  [_ 
|  \_/  ||    _]|    \ |     ||  D  | |  | |  |  |    |  D  ||  O  |    |   __||    _]
|   |   ||   [_ |     \|  _  ||     | |  | |  |  |    |     ||     |    |  /  ||   [_ 
|   |   ||     ||  .  ||  |  ||     | |  | |  |  |    |     ||     |    |     ||     |
|___|___||_____||__|\_||__|__||_____||____||__|__|    |_____| \___/     |_____||_____|
                                                                                      
");
  Console.WriteLine(" 1 - Adicionar um produto");
  Console.WriteLine(" 2 - Visualizar Produtos");
  Console.WriteLine(" 3 - Atualizar Produto");
  Console.WriteLine(" 4 - Deletar Produto");
  Console.WriteLine(" 5 - Buscar Produto");
  Console.WriteLine(" 6 - Relatório do estoque");
  System.Console.Write(" - ");
  int opcao = Convert.ToInt32(Console.ReadLine());
  switch (opcao)
  {
    case 1:
      Produto novoProduto = addProduto();
      produtos.Add(novoProduto);
      break;
    case 2:
      listarProdutos();
      break;
    case 3:
      atualizarProduto();
      break;
    case 4:
      deletarProduto();
      break;
    case 5:
      buscarProdutos();
      break;
    case 6:
      relatorioEstoque();
      break;
  }
}
static Produto addProduto()
{
  Console.Clear();
  Produto produto = new Produto();

  string nome;
  do
  {
    System.Console.Write("Digite o nome do produto: ");
    nome = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(nome))
    {
      Console.WriteLine("O nome do produto é obrigatório.");
    }
  } while (string.IsNullOrWhiteSpace(nome));
  produto.Nome = nome;


  Console.Write("Descriçao: ");
  produto.Descricao = Console.ReadLine();

  decimal Preco;
  while (true)
  {
    Console.Write("Preço: ");
    if (decimal.TryParse(Console.ReadLine(), out Preco) && Preco >= 0)
    {
      break;
    }
    System.Console.Write("Preco inválido, insira um número!");
  }
  produto.Preco = Preco;



  Console.Write("Marca: ");
  produto.Marca = Console.ReadLine();
  return produto;
}

void listarProdutos()
{
  Console.Clear();
  if (produtos.Count == 0)
  {
    System.Console.WriteLine("Nem um produto cadastrado!");
  }
  else
  {
    foreach (var produto in produtos)
    {
      System.Console.WriteLine($"Nome: {produto.Nome} , Descrição: {produto.Descricao}, preço: {produto.Preco:c}, Marca: {produto.Marca}");
    }
  }
  Console.ReadKey();
}

void atualizarProduto()
{
  listarProdutos();
  Console.Write("Digite o nome do produto a ser atualizado: ");
  string nomeProduto = Console.ReadLine();
  Produto produtoAtualizado = produtos.Find(p => p.Nome.Equals(nomeProduto, StringComparison.OrdinalIgnoreCase));
  //Pesquisar sobre estes metodos acima {.Find, .Equals, StringComparison.OrdinalIgnoreCase} //

  if (produtoAtualizado != null)
  {
    Console.WriteLine("Novo nome: ");
    produtoAtualizado.Nome = Console.ReadLine();

    Console.WriteLine("Nova descrição: ");
    produtoAtualizado.Descricao = Console.ReadLine();

    decimal novopreco;
    while (true)
    {
      Console.WriteLine("Novo Preço: ");
      if (decimal.TryParse(Console.ReadLine(), out novopreco) && novopreco >= 0)
      {
        break;
      }
      Console.WriteLine("Preço inválido, tente novamente!");

    }
    produtoAtualizado.Preco = novopreco;

    Console.WriteLine("Nova Marca: ");
    produtoAtualizado.Marca = Console.ReadLine();
  }
  else
  {
    Console.WriteLine("Produto Não encontrado!");
  }
}

void deletarProduto()
{
  Console.Write("Digite o nome do produto a ser deletado:");
  string produtoDeletar = Console.ReadLine();
  Produto produtoParaDeletar = produtos.Find(p => p.Nome.Equals(produtoDeletar, StringComparison.OrdinalIgnoreCase));

  if (produtoDeletar != null)
  {
    produtos.Remove(produtoParaDeletar);
    Console.WriteLine("O produto foi deletado com sucesso!");
  }
  else
  {
    Console.WriteLine("Produto não encontrado...");
  }
}

void buscarProdutos()
{
  Console.WriteLine("Nome do produto que deseja procurar: ");
  string produtoAhBuscar = Console.ReadLine();
  Produto produtoBuscado = produtos.Find(p => p.Nome.Equals(produtoAhBuscar, StringComparison.OrdinalIgnoreCase));

  if (produtoBuscado != null)
  {
    Console.WriteLine($"Nome: {produtoBuscado.Nome}, Descrição: {produtoBuscado.Descricao}, Preço: {produtoBuscado.Preco:C}, Marca: {produtoBuscado.Marca}");
  }
  else
  {
    Console.WriteLine("Produto não encontrado.");
  }
}

void relatorioEstoque()
{
  if (produtos.Count == 0)
  {
    Console.WriteLine("Nenhum produto no estoque.");
  }
  else
  {
    decimal totalEstoque = 0;
    foreach (var produto in produtos)
    {
      totalEstoque += produto.Preco;
    }
    Console.WriteLine($"Total de produtos: {produtos.Count}");
    Console.WriteLine($"Valor total do estoque: {totalEstoque:C}");
  }
}


class Produto
{
  public string Nome { get; set; }
  public string Descricao { get; set; }
  public decimal Preco { get; set; }
  public string Marca { get; set; }

}