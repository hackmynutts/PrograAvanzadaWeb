namespace ProjectAgileBoard.xUnit
{
    public class UnitTest1
    {
        [Fact]//para que sea una prueba unitaria, se debe agregar el atributo [Fact] al método de prueba
        public void Test1()
        {
            int prueba = 2+2;
            Assert.Equal(4, prueba);
        }
    }
}