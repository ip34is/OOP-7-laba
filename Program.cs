using System;

public class List
{
    private class Node
    {
        public double Data;
        public Node Next;

        public Node(double v)
        {
            Data = v;
            Next = null;
        }
    }

    private Node m_head;
    private int m_size;

    public List()
    {
        m_head = null;
        m_size = 0;
    }

    public void PushFront(double v)
    {
        Node node = new Node(v);
        if (m_head == null)
        {
            m_head = node;
        }
        else
        {
            node.Next = m_head;
            m_head = node;
        }
        ++m_size;
    }

    public void PopFront()
    {
        if (m_head != null)
        {
            Node next = m_head.Next;
            m_head = next;
            --m_size;
        }
    }

    public double this[int i]
    {
        get
        {
            Node node = m_head;
            while (i > 0 && node != null)
            {
                node = node.Next;
                --i;
            }
            return node.Data;
        }
    }
    
    public double average(){
        double avg = 0;
        Node node = m_head;
        while(node != null){
            avg += node.Data;
            node = node.Next;
        }

        return avg/m_size;
    }

    public double task1(){
        double avg = average();
        double result = avg;
        Node node = m_head;
        while(node != null && node.Data <= avg){node = node.Next;};
        if(node != null){
            result = node.Data;
        }
        return result;
    }

    public double task(double value){
        double result = 0;
        Node node = m_head;
        while(node != null){
            if(node.Data > value)
                result += node.Data;
            node = node.Next;
        }
        return result;
    }


    public List task3(){
        double avg = average();
        System.Console.WriteLine(avg);
        List result = new List();
        Node node = m_head;
        while(node != null){
            if(node.Data < avg)
                result.PushFront(node.Data);
            node = node.Next;
        }
        return result;
    }

    public void task4(){
        Node node = m_head;
        int i = 1;
        while(node != null && node.Next != null){
            if(i % 2 == 1){
                node.Next = node.Next.Next;
                i++;
            }
            node = node.Next;
            i++;
        }
    }

    public void Print(){
        Node node = m_head;
        while(node != null){
            System.Console.Write(node.Data.ToString() + " ");
            node = node.Next;
        }
    }

    public static int Main(string[] args){
        List list = new List();
        for(int i = 1; i <= 20; i++)
            list.PushFront(21 - i);
        System.Console.WriteLine("Введіть номер бажаної операції:\n1.Знайти перший елемент більший за середнє значення.\n2.Знайти суму елементів, значення яких більші за задане значення.\n3.Отримати новий список зі значень елементів менших за середнє значення.\n4.Видалити непарні елементи листа(нумерація починається з 1)");                
        int option;
        int.TryParse(Console.ReadLine(), out option);
        switch (option)
        {
            case 1:
                list.Print();
                System.Console.WriteLine(); 
                double firsttask = list.task1();
                System.Console.WriteLine(firsttask);
                break;
            case 2:
                list.Print();
                System.Console.WriteLine(); 
                System.Console.WriteLine("Введіть значення");
                int v = int.Parse(Console.ReadLine());
                double sum = list.task(v);
                System.Console.WriteLine(sum);
                break;
            case 3:
                List thirdtask = new List();
                thirdtask = list.task3();
                thirdtask.Print();
                break;
            case 4:
                list.task4();
                list.Print(); 
                break;
            default:
                System.Console.WriteLine("Введіть коректне значення");
                break;
        }
        return 0;
    }
}