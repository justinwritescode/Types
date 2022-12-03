/*
 * MediaTypeNames.cs
 *
 *   Created: 2022-11-29-01:56:37
 *   Modified: 2022-11-29-04:39:51
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Net.Mime.MediaTypes;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


public static class ApplicationMediaTypeNames
{
    public const string Octet = "application/octet-stream";
    public const string Pdf = "application/pdf";
    public const string Rtf = "application/rtf";
    public const string Soap = "application/soap+xml";
    public const string Xml = "application/xml";
    public const string Zip = "application/zip";
    public const string Json = "application/json";
    public const string JsonWithPlainText = "application/json+plaintext";
    public const string FormUrlEncoded = "application/x-www-formurlencoded";
}

[GenerateEnumerationClass("ApplicationMediaType", "System.Net.Mime.MediaTypes")]
public enum ApplicationMediaTypesEnum
{
    [Display(Name = ApplicationMediaTypeNames.Octet, Description = nameof(Octet))]
    [EnumMember(Value = ApplicationMediaTypeNames.Octet)]
    Octet,

    [Display(Name = ApplicationMediaTypeNames.Pdf, Description = nameof(Pdf))]
    [EnumMember(Value = ApplicationMediaTypeNames.Pdf)]
    Pdf,

    [Display(Name = ApplicationMediaTypeNames.Rtf, Description = nameof(Rtf))]
    [EnumMember(Value = ApplicationMediaTypeNames.Rtf)]
    Rtf,

    [Display(Name = ApplicationMediaTypeNames.Soap, Description = nameof(Soap))]
    [EnumMember(Value = ApplicationMediaTypeNames.Soap)]
    Soap,

    [Display(Name = ApplicationMediaTypeNames.Xml, Description = nameof(Xml))]
    [EnumMember(Value = ApplicationMediaTypeNames.Xml)]
    Xml,

    [Display(Name = ApplicationMediaTypeNames.Zip, Description = nameof(Zip))]
    [EnumMember(Value = ApplicationMediaTypeNames.Zip)]
    Zip,

    [Display(Name = ApplicationMediaTypeNames.Json, Description = nameof(Json))]
    [EnumMember(Value = ApplicationMediaTypeNames.Json)]
    Json,

    [Display(Name = ApplicationMediaTypeNames.FormUrlEncoded, Description = nameof(FormUrlEncoded))]
    [EnumMember(Value = ApplicationMediaTypeNames.FormUrlEncoded)]
    FormUrlEncoded
}

public static class TextMediaTypeNames
{
    public const string Html = "text/html";
    public const string Plain = "text/plain";
    public const string RichText = "text/richtext";
    public const string Xml = "text/xml";
    public const string Csv = "text/csv";
    public const string Css = "text/css";
    public const string Javascript = "text/javascript";
    public const string Json = "text/json";
}

[GenerateEnumerationClass("TextMediaType", "System.Net.Mime.MediaTypes")]
public enum TextEnum
{
    [Display(Name = TextMediaTypeNames.Html, Description = nameof(Html))]
    [EnumMember(Value = TextMediaTypeNames.Html)]
    Html,

    [Display(Name = TextMediaTypeNames.Plain, Description = nameof(Plain))]
    [EnumMember(Value = TextMediaTypeNames.Plain)]
    Plain,

    [Display(Name = TextMediaTypeNames.RichText, Description = nameof(RichText))]
    [EnumMember(Value = TextMediaTypeNames.RichText)]
    RichText,

    [Display(Name = TextMediaTypeNames.Xml, Description = nameof(Xml))]
    [EnumMember(Value = TextMediaTypeNames.Xml)]
    Xml,

    [Display(Name = TextMediaTypeNames.Csv, Description = nameof(Csv))]
    [EnumMember(Value = TextMediaTypeNames.Csv)]
    Csv,

    [Display(Name = TextMediaTypeNames.Css, Description = nameof(Css))]
    [EnumMember(Value = TextMediaTypeNames.Css)]
    Css,

    [Display(Name = TextMediaTypeNames.Javascript, Description = nameof(Javascript))]
    [EnumMember(Value = TextMediaTypeNames.Javascript)]
    Javascript,

    [Display(Name = TextMediaTypeNames.Json, Description = nameof(Json))]
    [EnumMember(Value = TextMediaTypeNames.Json)]
    Json
}

public static class ImageMediaTypeNames
{
    public const string Gif = "image/gif";
    public const string Jpeg = "image/jpeg";
    public const string Png = "image/png";
    public const string Tiff = "image/tiff";
    public const string Svg = "image/svg+xml";
}

[GenerateEnumerationClass("ImageMediaType", "System.Net.Mime.MediaTypes")]
public enum ImageEnum
{
    [Display(Name = ImageMediaTypeNames.Gif, Description = nameof(Gif))]
    [EnumMember(Value = ImageMediaTypeNames.Gif)]
    Gif,

    [Display(Name = ImageMediaTypeNames.Jpeg, Description = nameof(Jpeg))]
    [EnumMember(Value = ImageMediaTypeNames.Jpeg)]
    Jpeg,

    [Display(Name = ImageMediaTypeNames.Png, Description = nameof(Png))]
    [EnumMember(Value = ImageMediaTypeNames.Png)]
    Png,

    [Display(Name = ImageMediaTypeNames.Tiff, Description = nameof(Tiff))]
    [EnumMember(Value = ImageMediaTypeNames.Tiff)]
    Tiff,

    [Display(Name = ImageMediaTypeNames.Svg, Description = nameof(Svg))]
    [EnumMember(Value = ImageMediaTypeNames.Svg)]
    Svg
}
