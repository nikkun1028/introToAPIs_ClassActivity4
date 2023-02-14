using System;

//the interface (and therefore, your class) should have at least three out of these four things:
//instance methods, properties, events, indexers.

namespace MyConsoleApp{

interface StudentInterface{
	string Name {get; set;}
	int ID {get; set;}
	bool Absence {get; set;}
	
	delegate void Notify(object source, EventArgs args);
	event Notify StudentIsAbsent;
	void checkAttendance(Student s);
	protected virtual void confirmAttendance(){
		if(StudentIsAbsent != null){
			StudentIsAbsent(this, null); 
			// if any subscribers, call the event
		}
	}
}


class Student: StudentInterface{
	private string name; // fields
	private int id; 
	private bool isAbsent;
	
	public string Name{ // properties
	 get {return name;}
	 set {name = value;}
	}
	
	public int ID{
		get {return id;}
		set {id = value;}
	}
	
	public bool Absence{
		get {return isAbsent;}
		set {isAbsent = value;}
	}
	
	
	public delegate void Notify(object source, EventArgs args);
	public event Notify StudentIsAbsent; // event
	
	public void checkAttendance(Student s){
		Console.WriteLine("Checking attendance for ", 
		s.Name, "... please wait...");
		
		confirmAttendance();
	}
	
	public void confirmAttendance(object source, EventArgs eventArgs){ 
	// event handler
		Console.WriteLine("Attendance is confirmed.");
	}
	
	
	
	// main code
	static void Main(string[] args){
		var student = new Student{};
		student.name = "Rei";
		student.id = "1234";
		student.isAbsent = true;
		
		student.StudentIsAbsent += student.confirmAttendance;
		student.checkAttendance(student);
		Console.ReadKey();
	}
	
} // end Student Class


} // end MyConsoleApp




