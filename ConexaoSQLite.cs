
using System.Data.SQLite;

namespace NOME_DO_SEU_PROJETO //alterar o namespace para o nome do seu projeto
{
    public static class ConexaoSQLite
    {
        private static SQLiteConnection sqliteConnection;

        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=c:\\dados\\Cadastro.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void CriarBanco()
        {
            try
            {
                SQLiteConnection.CreateFile(@"c:\dados\Cadastro.sqlite");
            }
            catch
            {
                throw;
            }
        }
        public static void CriarTabelas()
        {
            try
            {
                //TABELA CLIENTE
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Cliente(Id int, Nome Varchar(100), CPF VarChar(15), Telefone VarChar(20), Email VarChar(100))";
                    cmd.ExecuteNonQuery();
                }

                //TABELA PRODUTO
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Produto(Id int, Descricao VarChar(100), ValorProduto decimal)";
                    cmd.ExecuteNonQuery();
                }

                //TABELA VENDA
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Venda(Id int, Cliente VarChar(100), ValorDesconto decimal, ValorFinal, decimal)";
                    cmd.ExecuteNonQuery();
                }

                //TABELA ProdutosVendas
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS ProdutosVendas(IdVenda int, IdProduto int, Quantidade int, ValorTotal decimal)";
                    cmd.ExecuteNonQuery();
                }

                //TABELA USUARIO
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Usuario(Login VarChar(100), Senha VarChar(100))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //CRUD DE CLIENTE (Construir método GET)
        public static void CadastrarCliente(Cliente obj) //Subtituir Objetc pelo nome da classe pessoa que foi criado
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Cliente(id, Nome, CPF, Telefone, Email) values (@id, @nome, @cpf, @telefone, @email)";
                    //incluir os atributos do objeto que foi passado no parametros. Ex.: obj.Id
                    cmd.Parameters.AddWithValue("@id", obj.Id);
                    cmd.Parameters.AddWithValue("@nome", obj.Nome);
                    cmd.Parameters.AddWithValue("@cpf", obj.CPF);
                    cmd.Parameters.AddWithValue("@telefone", obj.Telefone);
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RemoverCliente(string CPF)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Cliente WHERE CPF = @cpf";
                cmd.Parameters.AddWithValue("@cpf", CPF);
                cmd.ExecuteNonQuery();
            }
        }

        public static void EditarCliente(Pessoa obj) //Subtituir Objetc pelo nome da classe pessoa que foi criado
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "Update Cliente SET id = @id, Nome = @nome, CPF = @cpf, Telefone = @telefone, Email = @email where CPF = @cpf";
                    //incluir os atributos do objeto que foi passado no parametros. Ex.: obj.Id
                    cmd.Parameters.AddWithValue("@id", obj.Id);
                    cmd.Parameters.AddWithValue("@nome", obj.Nome);
                    cmd.Parameters.AddWithValue("@cpf", obj.CPF);
                    cmd.Parameters.AddWithValue("@telefone", obj.Endereco);
                    cmd.Parameters.AddWithValue("@email", obj.PossuiCNH);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //CRUD USUARIO (Construir método GET)
        public static void CadastrarUsuario(Usuario obj) //Subtituir Objetc pelo nome da classe pessoa que foi criado
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Usuario(Id, Login, Senha) values (@id, @login, @senha)";
                    //incluir os atributos do objeto que foi passado no parametros. Ex.: obj.Id
                    cmd.Parameters.AddWithValue("@id", obj.Id);
                    cmd.Parameters.AddWithValue("@login", obj.Login);
                    cmd.Parameters.AddWithValue("@senha", obj.Senha);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RemoverUsuario(int id)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Usuario WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        public static void EditarUsuario(Usuario obj)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "Update Usuario SET id = @id, Login = @login, Senha = @senha where Id = @id";
                    //incluir os atributos do objeto que foi passado no parametros. Ex.: obj.Id
                    cmd.Parameters.AddWithValue("@id", obj.Id);
                    cmd.Parameters.AddWithValue("@login", obj.Login);
                    cmd.Parameters.AddWithValue("@senha", obj.Senha);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidarUsuario(Usuario obj)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuario WHERE Login = @login and Senha = @senha";
                    //incluir os atributos do objeto que foi passado no parametros. Ex.: obj.Id
                    cmd.Parameters.AddWithValue("@login", obj.Login);
                    cmd.Parameters.AddWithValue("@senha", obj.Senha);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao logar: " + ex.Message);
                return false;
            }
        }


        //CRUD PRODUTOS (Construir método GET)
        public static void CadastrarProdutos(Produto obj)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Produto(Id, Descricao, ValorProduto) values (@id, @descricao, @valor)";
                    //incluir os atributos do objeto que foi passado no parametros. Ex.: obj.Id
                    cmd.Parameters.AddWithValue("@id", obj.Id);
                    cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                    cmd.Parameters.AddWithValue("@valor", obj.ValorProduto);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RemoverProduto(int id)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Produto WHERE Id = @id)";
                    cmd.Parameters.AddWithValue("@id", obj.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EditarProduto(Produto obj)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "Update Produto SET Descricao = @descricao, ValorProduto = @valor WHERE Id = @id)";
                    //incluir os atributos do objeto que foi passado no parametros. Ex.: obj.Id
                    cmd.Parameters.AddWithValue("@id", obj.Id);
                    cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                    cmd.Parameters.AddWithValue("@valor", obj.ValorProduto);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		
		
		
		
        //CADASTRO VENDAS
        public static void CadastrarVenda(Venda obj)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Venda(Id, Cliente, ValorDesconto, ValorFinal) values (@id, @cliente, @valorDesconto, @valorFinal)";
                    //incluir os atributos do objeto que foi passado no parametros. Ex.: obj.Id
                    cmd.Parameters.AddWithValue("@id", obj.Id);
                    cmd.Parameters.AddWithValue("@cliente", obj.Cliente);
                    cmd.Parameters.AddWithValue("@valorDesconto", obj.ValorDesconto);
                    cmd.Parameters.AddWithValue("@valorFinal", obj.ValorFinal);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //CADASTRO PRODUTOS DA VENDA
        public static void CadastrarProdutosVenda(ProdutoVenda obj)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO ProdutosVendas(IdVenda, IdProduto, Quantidade, ValorTotal) values (@idVenda, @idProduto, @qtd, @valor)";
                    //incluir os atributos do objeto que foi passado no parametros. Ex.: obj.Id
                    cmd.Parameters.AddWithValue("@idVenda", obj.IdVenda);
                    cmd.Parameters.AddWithValue("@idProduto", obj.IdProduto);
                    cmd.Parameters.AddWithValue("@qtd", obj.Quantidade);
                    cmd.Parameters.AddWithValue("@valor", obj.ValorTotal);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
