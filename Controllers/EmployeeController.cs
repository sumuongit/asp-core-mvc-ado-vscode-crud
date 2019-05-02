using System.Collections.Generic;   
using System.Linq;   
using Microsoft.AspNetCore.Mvc;  
using ASPCORE_MVC_VSCODE_ADO.Models;  
  
namespace ASPCORE_MVC_VSCODE_ADO.Controllers  
{  
    public class EmployeeController : Controller  
    {  
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();  
  
        public IActionResult Index()  
        {  
            List<Employee> lstEmployee = new List<Employee>();  
            lstEmployee = objemployee.GetAllEmployees().ToList();  
  
            return View(lstEmployee);  
        }  
    
    [HttpGet]  
    public IActionResult Create()  
    {  
        return View();  
    }  
    
    [HttpPost]  
    [ValidateAntiForgeryToken]  
    public IActionResult Create([Bind] Employee employee)  
    {  
        if (ModelState.IsValid)  
        {  
            objemployee.AddEmployee(employee);  
            return RedirectToAction("Index");  
        }  
        return View(employee);  
    }

    [HttpGet]  
    public IActionResult Edit(int? id)  
    {  
        if (id == null)  
        {  
            return NotFound();  
        }  
        Employee employee = objemployee.GetEmployeeData(id);  
    
        if (employee == null)  
        {  
            return NotFound();  
        }  
        return View(employee);  
    }  
    
    [HttpPost]  
    [ValidateAntiForgeryToken]  
    public IActionResult Edit(int id, [Bind]Employee employee)  
    {  
        if (id != employee.ID)  
        {  
            return NotFound();  
        }  
        if (ModelState.IsValid)  
        {  
            objemployee.UpdateEmployee(employee);  
            return RedirectToAction("Index");  
        }  
        return View(employee);  
    }

    [HttpGet]  
    public IActionResult Details(int? id)  
    {  
        if (id == null)  
        {  
            return NotFound();  
        }  
        Employee employee = objemployee.GetEmployeeData(id);  
    
        if (employee == null)  
        {  
            return NotFound();  
        }  
        return View(employee);  
    }

    [HttpGet]  
    public IActionResult Delete(int? id)  
    {  
        if (id == null)  
        {  
            return NotFound();  
        }  
        Employee employee = objemployee.GetEmployeeData(id);  
    
        if (employee == null)  
        {  
            return NotFound();  
        }  
        return View(employee);  
    }  
  
    [HttpPost, ActionName("Delete")]  
    [ValidateAntiForgeryToken]  
    public IActionResult DeleteConfirmed(int? id)  
    {  
        objemployee.DeleteEmployee(id);  
        return RedirectToAction("Index");  
    }
   }
}