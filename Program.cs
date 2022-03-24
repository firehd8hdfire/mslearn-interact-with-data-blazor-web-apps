using BlazingPizza;

using System;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");


var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");


// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}



        //declaring an int array
         MyGenericArray<int> intArray = new MyGenericArray<int>(5);
         
         //setting values
         for (int c = 0; c < 5; c++) {
            intArray.setItem(c, c*5);
         }
         
         //retrieving the values
         for (int c = 0; c < 5; c++) {
            Console.Write(intArray.getItem(c) + " ");
         }
         
         Console.WriteLine();
         
         //declaring a character array
         MyGenericArray<char> charArray = new MyGenericArray<char>(5);
         
         //setting values
         for (int c = 0; c < 5; c++) {
            charArray.setItem(c, (char)(c+97));
         }
         
         //retrieving the values
         for (int c = 0; c< 5; c++) {
            Console.Write(charArray.getItem(c) + " ");
         }
         Console.WriteLine();


namespace GenericMethodAppl {
   class Program {
      static void Swap<T>(ref T lhs, ref T rhs) {
         T temp;
         temp = lhs;
         lhs = rhs;
         rhs = temp;
      }
      static void Main(string[] args) {
         int a, b;
         char c, d;
         a = 10;
         b = 20;
         c = 'I';
         d = 'V';
         
         //display values before swap:
         Console.WriteLine("Int values before calling swap:");
         Console.WriteLine("a = {0}, b = {1}", a, b);
         Console.WriteLine("Char values before calling swap:");
         Console.WriteLine("c = {0}, d = {1}", c, d);
         
         //call swap
         Swap<int>(ref a, ref b);
         Swap<char>(ref c, ref d);
         
         //display values after swap:
         Console.WriteLine("Int values after calling swap:");
         Console.WriteLine("a = {0}, b = {1}", a, b);
         Console.WriteLine("Char values after calling swap:");
         Console.WriteLine("c = {0}, d = {1}", c, d);
         
         Console.ReadKey();
      }
   }
}

app.Run();


public class MyGenericArray<T> {
      private T[] array;
      
      public MyGenericArray(int size) {
         array = new T[size + 1];
      }
      public T getItem(int index) {
         return array[index];
      }
      public void setItem(int index, T value) {
         array[index] = value;
      }
   }




