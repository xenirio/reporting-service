﻿using Xenirio.Component.Gutenberg.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Xenirio.Component.Gutenberg.Tests
{
    [TestClass]
    public class ReportDocumentSpec
    {
        [TestMethod]
        public void Should_Replace_Label_Element()
        {
            var sourcefile = Environment.CurrentDirectory + @"\Resources\Sample.docx";
            var outfile = Environment.CurrentDirectory + @"\Resources\SampleTest.docx";
            if (File.Exists(outfile))
                File.Delete(outfile);
            File.Copy(sourcefile, outfile);
            var document = new ReportDocument();

            document.InjectReportElement(new ReportLabel() { Key = "Header.Entity.Name", Value = "IPO of Ezra Holdings Limited" });
            document.InjectReportElement(new ReportLabel() { Key = "Footer.Creator", Value = "Vee" });
            document.InjectReportElement(new ReportLabel() { Key = "Content.Entity.Name", Value = "IPO of Ezra Holdings Limited" });
            document.InjectReportElement(new ReportLabels() { Key = "Content.Entity.Names", Values = new string[] { "IPO of Ezra Holdings Limited", "IPO of Ezra" } });
            document.InjectReportElement(new ReportLabel() { Key = "Content.Entity.Remark", Value = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sollicitudin blandit massa, sit amet ornare odio aliquet a. Aliquam ac porttitor lacus. Duis molestie felis convallis, volutpat orci et, ornare tellus. Proin sed risus sit amet nunc faucibus pharetra. Curabitur imperdiet, lectus vitae accumsan semper, justo magna hendrerit lacus, eget iaculis felis quam non nunc. Vestibulum condimentum congue lectus, et consequat augue venenatis sit amet. Vivamus id efficitur nunc, sed suscipit lacus. Vivamus eleifend vestibulum tortor id ullamcorper. Phasellus nec fringilla mauris, eu aliquam nulla. In hac habitasse platea dictumst. Nullam venenatis tristique hendrerit. Maecenas a tellus euismod sapien elementum lobortis. Donec a felis imperdiet, cursus lorem at, porttitor odio.

Morbi eget lobortis sapien.Integer non fermentum ante.Mauris non fermentum ipsum,
				porttitor mollis erat.Phasellus massa nibh,
				vehicula vestibulum pharetra id,
				posuere quis sapien.In ullamcorper velit diam,
				et luctus nulla auctor at.Morbi tempus sollicitudin ex,
				lobortis efficitur quam gravida ornare.Donec et vestibulum sapien.Donec fermentum lectus enim,
				nec consequat metus varius a.Vestibulum dignissim vestibulum eros,
				vel euismod nisi condimentum non.

Ut maximus dui arcu,
				volutpat bibendum lorem convallis vel.Morbi iaculis at augue ornare efficitur.Nulla eu convallis odio.Duis quis leo euismod,
				varius ex blandit,
				luctus quam.Aenean pharetra magna non placerat sodales.Nulla sed purus et ipsum molestie faucibus at ac nunc.Pellentesque imperdiet euismod mauris nec varius.Fusce mollis condimentum mi,
				eget sodales lectus tempor quis.Pellentesque eleifend cursus nibh,
				et sodales lacus tempus et.Nam condimentum varius porta.

Suspendisse potenti.Morbi in varius nisi.Nunc nec diam metus.In ullamcorper sit amet elit in malesuada.Mauris aliquam nibh ornare quam iaculis euismod.Maecenas porta mollis diam,
				quis rhoncus ante maximus vel.Mauris nec tincidunt elit.Sed consequat commodo dignissim.Nunc eu egestas enim.Morbi et magna ut nisl imperdiet consectetur eu eu diam.Praesent vel ante consectetur,
				sodales erat ac,
				finibus risus.Praesent quis suscipit odio.

Cras vel suscipit ex.Fusce quis egestas ex.Nunc mattis arcu sit amet felis ultricies condimentum.Sed eget placerat nulla,
				vitae ultricies ex.Duis bibendum luctus mauris lacinia dapibus.Vivamus consectetur lacus laoreet consequat ultrices.Donec ligula eros,
				pretium ut magna id,
				pharetra aliquet velit.Duis auctor semper nisi." });
            document.InjectReportElement(new ReportLabel() { Key = "Content.Entity.Remark.Chinese", Value = @"Lorem存有悲坐阿梅德，consectetur adipiscing ELIT。然而，关心群众坐，很多足球恨香蕉。信用评级机构的sed arcu交流porttitor拉克丝。作业电视台的足球成就，而临床检查，以适应区域。但是，现在很多笑声微波下巴颤抖的。 Curabitur imperdiet，lectus简历accumsan森佩尔胡斯托麦格纳hendrerit ullamcorper英里，ID iaculis猫，他们现在要做的不是。规划毕业酱制造和摄影宣传消毒胡萝卜。这使我们现在可是好东西生活。 Eleifend Vivamus前庭tortor ID ullamcorper。 Phasellus NEC燕雀mauris，欧盟aliquam法无。再融资。局伤心继电器消毒。性能SAPIEN SAPIEN无线网元的政策。直到在，创新的硬件足球融资运行LOREM。

足球SAPIEN需要纸箱。整数暖锋。发酵存有mauris非，porttitor油树了。 Phasellus accumsan DUI NIBH，vehicula前庭pharetra ID，posuere QUIS SAPIEN。笔记本电脑的视频电缆，如笔者在零。 Morbi tempor sollicitudin出来，它变得比孕妇ornare lobortis。拱门直到SAPIEN。 Donec发酵lectus enim，从eget欧盟turpis NEC consequat。制造赌波观光，或直到酱性能。" });
            document.Save(outfile);
        }

        [TestMethod]
        public void Should_Replace_Table_Element()
        {
            var sourcefile = Environment.CurrentDirectory + @"\Resources\SampleTable.docx";
            var outfile = Environment.CurrentDirectory + @"\Resources\SampleTableTest.docx";
            if (File.Exists(outfile))
                File.Delete(outfile);
            File.Copy(sourcefile, outfile);
            var document = new ReportDocument();

            document.InjectReportElement(new ReportTable()
            {
                Key = "Content.Table.Entity",
                Elements = new ReportLabel[][] {
                    new ReportLabel[] {
                        new ReportLabel() { Value = "Coopers" },
                        new ReportLabel() { Value = "Firm" },
                        new ReportLabel() { Value = "Chiang Mai" },
                        new ReportLabel() { Value = "John" },
                        new ReportLabel() { Value = "Good" },
                    },
                    new ReportLabel[] {
                        new ReportLabel() { Value = "John" },
                        new ReportLabel() { Value = "Person" },
                        new ReportLabel() { Value = "USA" },
                        new ReportLabel() { Value = "John" },
                        new ReportLabel() { Value = "Good" }
                    }
                }
            });
            document.Save(outfile);
        }

        [TestMethod]
        public void Should_Replace_Expandable_Table_Element()
        {
            var sourcefile = Environment.CurrentDirectory + @"\Resources\SampleExpandableTable.docx";
            var outfile = Environment.CurrentDirectory + @"\Resources\SampleExpandableTableTest.docx";
            if (File.Exists(outfile))
                File.Delete(outfile);
            File.Copy(sourcefile, outfile);
            var document = new ReportDocument();

            document.InjectReportElement(new ReportTable()
            {
                Key = "Content.Table.Entity",
                Elements = new ReportLabel[][] {
                    new ReportLabel[] {
                        new ReportLabel() { Value = "" },
                        new ReportLabel() { Value = "31 DEC 2017" },
                        new ReportLabel() { Value = "31 DEC 2016" },
                        new ReportLabel() { Value = "31 DEC 2015" },
                        new ReportLabel() { Value = "31 DEC 2014" },
                        new ReportLabel() { Value = "31 DEC 2013" }
                    },
                    new ReportLabel[] {
                        new ReportLabel() { Value = "Period Start Date" },
                        new ReportLabel() { Value = "1 JAN 2017" },
                        new ReportLabel() { Value = "1 JAN 2016" },
                        new ReportLabel() { Value = "1 JAN 2015" },
                        new ReportLabel() { Value = "1 JAN 2014" },
                        new ReportLabel() { Value = "12 APR 2013" }
                    },
                    new ReportLabel[] {
                        new ReportLabel() { Value = "Period End Date" },
                        new ReportLabel() { Value = "31 DEC 2017" },
                        new ReportLabel() { Value = "31 DEC 2016" },
                        new ReportLabel() { Value = "31 DEC 2015" },
                        new ReportLabel() { Value = "31 DEC 2014" },
                        new ReportLabel() { Value = "31 DEC 2013" }
                    },
                    new ReportLabel[] {
                        new ReportLabel() { Value = "Account Type" },
                        new ReportLabel() { Value = "COMPANY" },
                        new ReportLabel() { Value = "COMPANY" },
                        new ReportLabel() { Value = "COMPANY" },
                        new ReportLabel() { Value = "COMPANY" },
                        new ReportLabel() { Value = "COMPANY" }
                    }
                }
            });
            document.Save(outfile);
        }

        [TestMethod]
        public void Should_Replace_Image_Element()
        {
            var sourcefile = Environment.CurrentDirectory + @"\Resources\SampleImage.docx";
            var outfile = Environment.CurrentDirectory + @"\Resources\SampleImageTest.docx";
            if (File.Exists(outfile))
                File.Delete(outfile);
            File.Copy(sourcefile, outfile);
            var document = new ReportDocument();

            document.InjectReportElement(new ReportImage()
            {
                Key = "Content.Image.Logo",
                Value = File.ReadAllBytes(Environment.CurrentDirectory + @"\Resources\logo.png")
            });
            document.InjectReportElement(new ReportImage()
            {
                Key = "Content.Image.Banner",
                Value = File.ReadAllBytes(Environment.CurrentDirectory + @"\Resources\banner.png")
            });
            document.Save(outfile);
        }

        [TestMethod]
        public void Should_Replace_Image_Table()
        {
            var sourcefile = Environment.CurrentDirectory + @"\Resources\SampleImageTable.docx";
            var outfile = Environment.CurrentDirectory + @"\Resources\SampleImageTableTest.docx";
            if (File.Exists(outfile))
                File.Delete(outfile);
            File.Copy(sourcefile, outfile);
            var document = new ReportDocument();

            var byteLogo = File.ReadAllBytes(Environment.CurrentDirectory + @"\Resources\logo.png");
            document.InjectReportElement(new ReportTable()
            {
                Key = "Content.Image.Logo",
                Elements = new ReportImage[][]{
                    new ReportImage[] {
                        new ReportImage(){ Value = byteLogo }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Value = byteLogo }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Value = byteLogo }
                    }
                }
            });
            document.InjectReportElement(new ReportImage()
            {
                Key = "Content.Image.Banner",
                Value = File.ReadAllBytes(Environment.CurrentDirectory + @"\Resources\banner.png")
            });
            document.Save(outfile);
        }

        [TestMethod]
        public void Should_Replace_Composite_Table()
        {
            var sourcefile = Environment.CurrentDirectory + @"\Resources\SampleCompositeTable.docx";
            var outfile = Environment.CurrentDirectory + @"\Resources\SampleCompositeTableTest.docx";
            if (File.Exists(outfile))
                File.Delete(outfile);
            File.Copy(sourcefile, outfile);
            var document = new ReportDocument();

            var byteLogo = File.ReadAllBytes(Environment.CurrentDirectory + @"\Resources\logo.png");
            document.InjectReportElement(new ReportTable()
            {
                Key = "Content.Image.Logo",
                Elements = new ReportElement[][]{
                    new ReportElement[] {
                        new ReportImage(){ Value = byteLogo },
                        new ReportLabel(){ Value = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                        new ReportLabel(){ Value = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." }
                    },
                    new ReportElement[] {
                        new ReportImage(){ Value = byteLogo },
                        new ReportLabel(){ Value = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                        new ReportLabel(){ Value = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." }
                    },
                    new ReportElement[] {
                        new ReportImage(){ Value = byteLogo },
                        new ReportLabel(){ Value = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                        new ReportLabel(){ Value = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." }
                    },
                }
            });
            document.InjectReportElement(new ReportImage()
            {
                Key = "Content.Image.Banner",
                Value = File.ReadAllBytes(Environment.CurrentDirectory + @"\Resources\banner.png")
            });
            document.Save(outfile);
        }

        [TestMethod]
        public void Should_Replace_Complex_Table()
        {
            var sourcefile = Environment.CurrentDirectory + @"\Resources\SampleTableAdvance.docx";
            var outfile = Environment.CurrentDirectory + @"\Resources\SampleTableAdvanceTest.docx";
            if (File.Exists(outfile))
                File.Delete(outfile);
            File.Copy(sourcefile, outfile);

            var byteBanner = File.ReadAllBytes(Environment.CurrentDirectory + @"\Resources\banner.png");
            var document = new ReportDocument();
            document.InjectReportElement(new ReportTableComplex()
            {
                Key = "Content.Table.Rule",
                Elements = new ReportElement[][] {
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Title", Value = "Rule 1" }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Entity.Name", Value = "ABC" }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Key = "Template.Rule.Entity.Map", Value = byteBanner }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Key = "Template.Rule.Entity.Map", Value = byteBanner }
                    },
                    new ReportImage[] {
                        new ReportImage(){ Key = "Template.Rule.Entity.Map", Value = byteBanner }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Entity.Name", Value = "DEF" }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Title", Value = "Rule 2" }
                    },
                    new ReportLabel[] {
                        new ReportLabel(){ Key = "Template.Rule.Entity.Name", Value = "GHI" }
                    },
                }
            });
            document.Save(outfile);
        }

        [TestMethod]
        public void Should_Replace_Apply_Table()
        {
            var sourcefile = Environment.CurrentDirectory + @"\Resources\SampleApplyTable.docx";
            var outfile = Environment.CurrentDirectory + @"\Resources\SampleApplyTableTest.docx";
            if (File.Exists(outfile))
                File.Delete(outfile);
            File.Copy(sourcefile, outfile);

            var document = new ReportDocument();
            document.InjectReportElement(new ReportTable()
            {
                Key = "Content.Rule.Header",
                Elements = new ReportLabel[][] {
                    new ReportLabel[] {
                        new ReportLabel() { Value = "Application ID" },
                        new ReportLabel() { Value = "Company UEN" }
                    }
                }
            });
            document.InjectReportElement(new ReportTable()
            {
                Key = "Content.Rule.Title2",
                Elements = new ReportLabel[][] {
                    new ReportLabel[] {
                        new ReportLabel() { Value = "The following are applicants/claimants with the same phone number" }
                    }
                }
            });
            document.InjectReportElement(new ReportTable()
            {
                Key = "Content.Rule.Table2",
                Elements = new ReportLabel[][] {
                    new ReportLabel[] {
                        new ReportLabel() { Value = "000" },
                        new ReportLabel() { Value = "AAA" }
                    },
                    new ReportLabel[] {
                        new ReportLabel() { Value = "001" },
                        new ReportLabel() { Value = "AAB" }
                    },
                    new ReportLabel[] {
                        new ReportLabel() { Value = "002" },
                        new ReportLabel() { Value = "AAC" }
                    }
                }
            });
            document.Save(outfile);
        }

        [TestMethod]
        public void Should_Replace_Report_Template()
        {
            var sourcefile = Environment.CurrentDirectory + @"\Resources\SampleContentTemplate.docx";
            var outfile = Environment.CurrentDirectory + @"\Resources\SampleContentTemplateTest.docx";
            if (File.Exists(outfile))
                File.Delete(outfile);
            File.Copy(sourcefile, outfile);
            var data = new string[][]{
                new string[] { "Fire Bolt", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ante tellus, porttitor sit amet pretium ut, luctus sed lorem. Praesent viverra accumsan porta. Mauris ante magna, condimentum in vestibulum efficitur, maximus at justo. Nulla eget nisi in dolor mollis tempus vitae sit amet lorem", "16" },
                new string[] { "Thunder Storm", "Pellentesque felis magna, congue et dolor quis, sagittis tristique nulla. Etiam tincidunt eleifend justo, at rhoncus nisi efficitur ac. Cras ipsum tellus, ultrices vitae nulla vel, posuere rhoncus leo. Aliquam volutpat erat nulla. Nam non elementum augue, sit amet tempor lorem", "12" },
                new string[] { "Cold Snap", "Curabitur vel turpis imperdiet, dignissim nulla at, dignissim orci. Fusce rutrum congue mauris, eget pulvinar est laoreet id. Vestibulum lobortis, mauris et varius condimentum, lectus risus bibendum dui, eget sodales lectus justo nec nibh. Sed ullamcorper magna et neque suscipit efficitur", "24" }
            }.Select(r =>
            {
                var result = new List<IReportReplaceable>();
                result.Add(new ReportLabel() { Key = "Skill.Name", Value = r[0] });
                result.Add(new ReportLabel() { Key = "Skill.Nickname", Value = r[2] });
                result.Add(new ReportLabel() { Key = "Skill.Effect", Value = r[1] });
                result.Add(new ReportLabel() { Key = "Skill.Cost", Value = r[2] });

                return result.ToArray();
            }).ToArray();
            
            var document = new ReportDocument();
            document.InjectReportElement(new ReportTemplateElement()
            {
                Key = "Content.Skills",
                TemplateKey = "Skill",
                Value = data
            });
            document.RegisterTemplate("Skill");
            document.Save(outfile);
        }

        [TestMethod]
        public void Should_Support_New_Line_Charactor()
        {
            var sourcefile = Environment.CurrentDirectory + @"\Resources\SampleLabel.docx";
            var outfile = Environment.CurrentDirectory + @"\Resources\SampleLabelTest.docx";
            if (File.Exists(outfile))
                File.Delete(outfile);
            File.Copy(sourcefile, outfile);
            var document = new ReportDocument();
            document.InjectReportElement(new ReportLabel()
            {
                Key = "Content.Text.SingleLabel",
                Value = "Hello\r\nสวัสดี\r\nこんにちは"
            });
            document.InjectReportElement(new ReportLabels()
            {
                Key = "Content.Text.MultipleLabel",
                Values = new string[]
                {
                    "Don't say anything\r\nอย่ามาพูดอะไรทั้งนั้นนะ\r\n何も言うな",
                    "You deserve it\r\nสมน้ำหน้า\r\nさまみろ！",
                    "さらば、俺の友よ"
                }
            });
            document.Save(outfile);
        }

        
        public void Should_Render_Template_With_Image_Element()
        {
            var sourcefile = Environment.CurrentDirectory + @"\Resources\SampleFlowerList.docx";
            var outfile = Environment.CurrentDirectory + @"\Resources\SampleFlowerListTest.docx";
            if (File.Exists(outfile))
                File.Delete(outfile);
            File.Copy(sourcefile, outfile);

            var imgLisianthus = File.ReadAllBytes(Environment.CurrentDirectory + @"\Resources\lisianthus.jpg");
            var imgPrimula = File.ReadAllBytes(Environment.CurrentDirectory + @"\Resources\primula.jpg");

            var data = new IReportReplaceable[][]
            {
                new IReportReplaceable[] {
                    new ReportImage() { Key = "Flower.Image", Value = imgLisianthus },
                    new ReportLabel() { Key = "Flower.Name", Value = "Lisianthus" },
                    new ReportLabel() { Key = "Flower.Meanings", Value = "Life long bond, Appreciation" }
                },
                new IReportReplaceable[] {
                    new ReportImage() { Key = "Flower.Image", Value = imgPrimula },
                    new ReportLabel() { Key = "Flower.Name", Value = "Primula" },
                    new ReportLabel() { Key = "Flower.Meanings", Value = "Youth, Young Love" }
                },
            };

            var document = new ReportDocument();
            document.InjectReportElement(new ReportTemplateElement()
            {
                Key = "Content.Flowers",
                TemplateKey = "Flower",
                Value = data
            });
            document.RegisterTemplate("Flower");
            document.Save(outfile);
        }

        [TestMethod]
        public void Should_Support_Paragraph_Styling()
        {
            var sourcefile = Environment.CurrentDirectory + @"\Resources\SampleStyling.docx";
            var outfile = Environment.CurrentDirectory + @"\Resources\SampleStylingTest.docx";
            if (File.Exists(outfile))
                File.Delete(outfile);
            File.Copy(sourcefile, outfile);
            var document = new ReportDocument();
            document.InjectReportElement(new ReportLabel()
            {
                Key = "Content.Should.Red",
                Value = "This is Red sentense.",
                Style = new ReportLabelStyle()
                {
                    Color = "#FF0000"
                }
            });
            document.InjectReportElement(new ReportLabel()
            {
                Key = "Content.Should.Green",
                Value = "This is Green sentense.",
                Style = new ReportLabelStyle()
                {
                    Color = "#00FF00"
                }
            });
            document.InjectReportElement(new ReportLabel()
            {
                Key = "Content.Should.Blue",
                Value = "This is Blue sentense.",
                Style = new ReportLabelStyle()
                {
                    Color = "#0000FF"
                }
            });
            document.InjectReportElement(new ReportLabel()
            {
                Key = "Content.Should.Bold",
                Value = "This is Bold sentense.",
                Style = new ReportLabelStyle()
                {
                    Bold = true
                }
            });
            document.InjectReportElement(new ReportLabel()
            {
                Key = "Content.Should.Italic",
                Value = "This is Italic sentense.",
                Style = new ReportLabelStyle()
                {
                    Italic = true
                }
            });
            document.Save(outfile);
        }

        [TestMethod]
        public void Should_Support_Inline_Paragraph()
        {
            var sourcefile = Environment.CurrentDirectory + @"\Resources\SampleInlineLabel.docx";
            var outfile = Environment.CurrentDirectory + @"\Resources\SampleInlineLabelTest.docx";
            if (File.Exists(outfile))
                File.Delete(outfile);
            File.Copy(sourcefile, outfile);
            var document = new ReportDocument();
            document.InjectReportElement(new ReportLabel()
            {
                Key = "Content.Inline.First",
                Value = "This is first inline text.",
                Style = new ReportLabelStyle()
                {
                    Color = "#FF0000"
                }
            });
            document.InjectReportElement(new ReportLabel()
            {
                Key = "Content.Inline.Second",
                Value = "This is second inline text.",
                Style = new ReportLabelStyle()
                {
                    Color = "#00FF00"
                }
            });
            document.Save(outfile);
        }
    }
}
