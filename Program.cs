using System;

public class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    public Karyawan(string nama, string id, double gajiPokok)
    {
        Nama = nama;
        ID = id;
        GajiPokok = gajiPokok;
    }

    public virtual double HitungGaji()
    {
        return GajiPokok;
    }
}

public class KaryawanTetap : Karyawan
{
    public KaryawanTetap(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return base.GajiPokok + 500000;
    }
}

public class KaryawanKontrak : Karyawan
{
    public KaryawanKontrak(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return base.GajiPokok - 200000;
    }
}

public class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return base.GajiPokok;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Pilih jenis karyawan:");
        Console.WriteLine("1. Karyawan Tetap");
        Console.WriteLine("2. Karyawan Kontrak");
        Console.WriteLine("3. Karyawan Magang");
        Console.Write("Masukkan pilihan (1-3): ");
        int pilihan = int.Parse(Console.ReadLine());

        Console.Write("Masukkan Nama: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan ID: ");
        string id = Console.ReadLine();

        Console.Write("Masukkan Gaji Pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;
        if (pilihan == 1)
            karyawan = new KaryawanTetap(nama, id, gajiPokok);
        else if (pilihan == 2)
            karyawan = new KaryawanKontrak(nama, id, gajiPokok);
        else if (pilihan == 3)
            karyawan = new KaryawanMagang(nama, id, gajiPokok);
        else
        {
            Console.WriteLine("Pilihan tidak valid!");
            return;
        }

        double gajiAkhir = karyawan.HitungGaji();
        Console.WriteLine($"\nGaji akhir untuk {karyawan.Nama} (ID: {karyawan.ID})");
        Console.WriteLine($"Sejumlah: {gajiAkhir}");
    }
}