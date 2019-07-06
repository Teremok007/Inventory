using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BarcodeFramework
{
  public interface IDataLibPlugin
  {
    //свойства плагинов
    string Datasource { get; set; }
    
    //bool Active { get; set; }
    string PluginFullName { get; }

    //методы управления БД
    bool ConnectDatabase();
    //bool DisconnectDatabase();
    
    //- получить детализацию штрихкода
    //IEnumerable<Ean> GetEanDetails(string barcode);    
    // создание нового заказа
    OrderItem Save(ref OrderItem orderItem);
    int ScanExport(string FileName);
    Ean GetEan(string barcode);
    int SprEanCount();
    // информация о БД
    DbInfo GetDbInfo();
    OrderItem GetOrderItemByEan(Ean ean);
    // Создает объект OrderItem по заданному штрих-коду
    OrderItem CreateOrderItemByBarcode(string barcode);
    // возварщает объект OrderItem по заданному штрих-коду
    OrderItem GetOrdeItemByBarcode(string barcode);
    // возвращает о скнировании (Арт-код и кол-во сканированного товара)
    ScanInfo GetScanInfo(int IdGamma);
    // возвращает список пользователей
    IEnumerable<Employee> GetEmployees();
    IEnumerable<ScanLog> GetAllScansLog();
    // Ищет в БД штрих-код пропуска сотрудника и возвращает объект Employee (сотркджник)
    Employee GetEmployee(string barcode);
    //сохраняет лог
    void SaveLog(ref ScanLog slog);
  }
}
