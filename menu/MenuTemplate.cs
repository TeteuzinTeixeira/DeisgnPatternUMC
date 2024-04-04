namespace Aula_01.menu;

public abstract class MenuTemplate
{
    public void run(int metodo)
    {
        this.limparTela();
        this.executarAcao(metodo);
    }

    protected abstract void executarAcao(int metodo);

    protected void limparTela()
    {
        Console.Clear();
    }
}