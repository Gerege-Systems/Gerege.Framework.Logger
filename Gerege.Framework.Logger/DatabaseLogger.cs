using System.Collections.Generic;

/////// date: 2021.12.03 //////////
///// author: Narankhuu ///////////
//// contact: codesaur@gmail.com //

namespace Gerege.Framework.Logger;

/// <summary>
/// Программ ажиллаж байх үед шаардлагатай лог мэдээллийг баазад цуглуулж хадгалах хийсвэр класс.
/// </summary>
public abstract class DatabaseLogger
{
    /// <summary>
    /// Мэдээллийн бааз үүсгэх/холбогдох/бэлдэх.
    /// <para>
    /// Үүнд: Лог хадгалах ерөнхий бааз бүтэцтэй холбогдож эсвэл үүсгэж, шаардлагатай хүснэгтүүд/файлууд/мужууд байгаа эсэхийг шалган үүсгэж бэлдэнэ.
    /// </para>
    /// </summary>
    /// <param name="connection">Лог удирдах ерөнхий бааз бүтэц нэр/холболтын тохиргоо.</param>
    /// <returns>Үйлдэл амжилттай эсэх boolean утга.</returns>
    public abstract bool Connect(string? connection = null);

    /// <summary>
    /// Мэдээллийн бааз унших/бичих үйлдэлд бэлэн эсэхийг шалгах.
    /// <para>
    /// Лог хадгалах/харах үйлдэл гүйцэтгэхээс өмнө заавал энэ фүнкц дуудагдан бүх зүйл хэвийн эсэхийг шалгадаг байх хэрэгтэй.
    /// Ямар нэг асуудал байвал Exception үүсгэн мэдэгдэх хэрэгтэй.
    /// </para>
    /// </summary>
    protected abstract bool Assert();

    /// <summary>
    /// Заасан түвшинд лог бичих.
    /// <para>
    /// Хөгжүүлэгч нь энэ функцийг удамшуулсан класс дээрээ override түлхүүр үгээр дахин функц болгон тодорхойлж шаардлагатай лог бичилтийн үйлдлийг оруулж өгөх ёстой.
    /// </para>
    /// </summary>
    /// <param name="table">Хадгалах хүснэгт,файл,талбар,муж аль ч байж болно. Лог хадгалах ерөнхий бааз бүтцээс шалтгаална.</param>
    /// <param name="level">Түвшин.</param>
    /// <param name="message">Тайлбар мессеж.</param>
    /// <param name="context">Өгөгдөл.</param>
    protected abstract void Log(string table, string level, string message, dynamic context);

    /// <summary>
    /// Хүснэгт/файл/талбар/муж - аас заасан түвшиний лог сонгож авах.
    /// </summary>
    /// <param name="table">Хүснэгт/файл/талбар/муж.</param>
    /// <param name="level">Түвшин. Хэрвээ утга * байвал түвшин хамаарахгүй сонгоно.</param>
    /// <param name="condition">Сонгох нөхцөл.</param>
    /// <returns>Сонгогдсон LogRecord бүтэцтэй лог мэдээллийн жагсаалт.</returns>
    public abstract List<Log> SelectFrom(string table, string level = "*", string condition = "");

    /// <summary>
    /// Хэвийн түвшинд лог бичих. Энгийн мэдээллүүд.
    /// </summary>
    /// <param name="table">Хадгалах хүснэгт/файл/талбар/муж аль ч байж болно. Лог хадгалах ерөнхий бааз бүтцээс шалтгаална.</param>
    /// <param name="message">Тайлбар мессеж.</param>
    /// <param name="context">Өгөгдөл.</param>
    public void Notice(string table, string message, dynamic context) => Log(table, "notice", message, context);

    /// <summary>
    /// Чухал үйл явдлын түвшинд лог бичих.
    /// <para>
    /// Хэрэглэгчээс төлбөр татсан, үйлчилгээ захиалга баталгаажсан гэх мэдээллүүд.
    /// </para>
    /// </summary>
    /// <param name="table">Хадгалах хүснэгт/файл/талбар/муж аль ч байж болно. Лог хадгалах ерөнхий бааз бүтцээс шалтгаална.</param>
    /// <param name="message">Тайлбар мессеж.</param>
    /// <param name="context">Өгөгдөл.</param>
    public void Info(string table, string message, dynamic context) => Log(table, "info", message, context);

    /// <summary>
    /// Ажлын алдааны түвшинд лог бичих.
    /// <para>
    /// Хувьсагчын төрөл зөрсөн, утга оноогдоогүй гэх мэт ажиллагааны үед гардаг ердийн алдааны мэдээлэл.
    /// </para>
    /// </summary>
    /// <param name="table">Хадгалах хүснэгт/файл/талбар/муж аль ч байж болно. Лог хадгалах ерөнхий бааз бүтцээс шалтгаална.</param>
    /// <param name="message">Тайлбар мессеж.</param>
    /// <param name="context">Өгөгдөл.</param>
    public void Error(string table, string message, dynamic context) => Log(table, "error", message, context);

    /// <summary>
    /// Сануулгын түвшинд лог бичих.
    /// Хуучирсан сервис ашиглаж байна шүү гэх мэт алдаа биш боловч анхаарах шаардлагатай мэдээлэл.
    /// </summary>
    /// <param name="table">Хадгалах хүснэгт/файл/талбар/муж аль ч байж болно. Лог хадгалах ерөнхий бааз бүтцээс шалтгаална.</param>
    /// <param name="message">Тайлбар мессеж.</param>
    /// <param name="context">Өгөгдөл.</param>
    public void Warning(string table, string message, dynamic context) => Log(table, "warning", message, context);

    /// <summary>
    /// Гэнэтийн тохиолдлын түвшинд лог бичих.
    /// <para>
    /// Урьдчилан тооцоогүй үйл явдлын лог.
    /// </para>
    /// </summary>
    /// <param name="table">Хадгалах хүснэгт/файл/талбар/муж аль ч байж болно. Лог хадгалах ерөнхий бааз бүтцээс шалтгаална.</param>
    /// <param name="message">Тайлбар мессеж.</param>
    /// <param name="context">Өгөгдөл.</param>
    public void Emergency(string table, string message, dynamic context) => Log(table, "emergency", message, context);

    /// <summary>
    /// Яаралтай хариу арга хэмжээ авах шаардлагатай түвшинд лог бичих.
    /// Үйлчилгээний сервист холбогдож чадахгүй байна гэх мэт даруй арга хэмжээ авах шаардлагатай мэдээллийг бүртгэн хариуцах газарт нь мэдээлдэг байх хэрэгтэй (Email, SMS илгээх гэх мэтээр).
    /// </summary>
    /// <param name="table">Хадгалах хүснэгт/файл/талбар/муж аль ч байж болно. Лог хадгалах ерөнхий бааз бүтцээс шалтгаална.</param>
    /// <param name="message">Тайлбар мессеж.</param>
    /// <param name="context">Өгөгдөл.</param>
    public void Alert(string table, string message, dynamic context) => Log(table, "alert", message, context);

    /// <summary>
    /// Түгшүүрийн түвшинд лог бичих.
    /// <para>
    /// DLL олдохгүй байна гэх мэт программын ажиллагаанд зайлшгүй шаардлагатай бүрэлдэхүүн хэсэг доголдсон талаарх мэдээлэл.
    /// </para>
    /// </summary>
    /// <param name="table">Хадгалах хүснэгт/файл/талбар/муж аль ч байж болно. Лог хадгалах ерөнхий бааз бүтцээс шалтгаална.</param>
    /// <param name="message">Тайлбар мессеж.</param>
    /// <param name="context">Өгөгдөл.</param>
    public void Сritical(string table, string message, dynamic context) => Log(table, "critical", message, context);

    /// <summary>
    /// Туршилтын түвшинд лог бичих.
    /// <para>
    /// Программын ажиллагаатай холбоотой өгөгдлийг нарийвчлан деталчилсан байдлаар хадгалсан мэдээлэл.
    /// </para>
    /// </summary>
    /// <param name="table">Хадгалах хүснэгт/файл/талбар/муж аль ч байж болно. Лог хадгалах ерөнхий бааз бүтцээс шалтгаална.</param>
    /// <param name="message">Тайлбар мессеж.</param>
    /// <param name="context">Өгөгдөл.</param>
    public void Trace(string table, string message, dynamic context) => Log(table, "trace", message, context);
}
