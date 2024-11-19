using NUnit.Framework;
using AltTester.AltTesterUnitySDK.Driver;
using UnityEngine;

public class TestAltUnity
{
    private AltDriver altDriver;

    [OneTimeSetUp]
    public void SetUp()
    {
        // Se añade una pausa de 3 segundos antes de inicializar el AltDriver, 
        //para esperar que el juego cargue correctamente
        System.Threading.Thread.Sleep(3000);
        // Inicializa una nueva instancia de AltDriver para controlar el juego durante las pruebas
        altDriver = new AltDriver();
    }

    // Este metodo se ejecuta una sola vez despues de que todas las pruebas hayan terminado
    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop(); // Detiene el AltDriver, lo que finaliza cualquier interacción con el juego
    }

    // Prueba para verificar si el boton de inicio esta visible y habilitado
    [Test]
    public void TestStartButtonVisibilityAndEnablement()
    {
        altDriver.WaitForCurrentSceneToBe("Main"); // Verifica que la escena actual sea "Main"
        var startButton = altDriver.WaitForObject(By.NAME, "StartButton"); // Espera el botón
        Assert.IsNotNull(startButton); // Verifica que el boton no sea nulo
        Assert.IsTrue(startButton.enabled); // Verifica que el boton esté habilitado
    }

    // Prueba para verificar si el modelo del personaje esta activo en la escena
    [Test]
    public void TestCharacterModelActiveState()
    {
        altDriver.LoadScene("Main"); // Carga la escena "Main"
        var characterModel = altDriver.WaitForObject(By.NAME, "character(Clone)"); // Espera al modelo del personaje
        Assert.IsNotNull(characterModel); // Verifica que el modelo del personaje no sea nulo
        Assert.IsTrue(characterModel.enabled); // Verifica que el modelo del personaje esté habilitado
    }

    

}