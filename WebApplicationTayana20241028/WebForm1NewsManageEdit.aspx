<%@ Page Title="" Language="C#" MasterPageFile="~/SiteBack.Master" AutoEventWireup="true" CodeBehind="WebForm1NewsManageEdit.aspx.cs" Inherits="WebApplicationTayana20241028.WebForm1NewsManageEdit" ValidateRequest="false" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="pc-container">
        <div class="pc-content">
            <!-- [ breadcrumb ] start -->
            <div class="page-header">
                <div class="page-block">
                    <div class="row align-items-center">
                        <div class="col-md-12">
                            <div class="page-header-title">
                                <h5 class="mb-0">Home</h5>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <ul class="breadcrumb mb-0">
                                <li class="breadcrumb-item"><a href="WebForm1BackIndex.aspx">Home</a></li>
                                <li class="breadcrumb-item" aria-current="page">News Edit</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!-- [ breadcrumb ] end -->
            <!-- [ Main Content ] start -->
            <div class="row">
                <!-- [ Recent Users ] start -->
                <div class="col-xl-8 col-md-6">
                    <div class="card Recent-Users">
                        <div class="card-header">
                            <h5>News Edit Table</h5>
                        </div>
                        <div class="card-body px-0 py-3">
                            <div class="table-responsive">
                                <table class="table table-hover">
                                    <tbody>
                                        <tr class="unread">
                                            <td>
                                                <label class="form-label">News Date</label>
                                                <asp:TextBox ID="TextBoxEditNewsDate" runat="server" class="form-control" placeholder="請輸入日期 yyyy-mm-dd"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ErrorMessage="請輸入yyyy-mm-dd格式"
                                                    ControlToValidate="TextBoxEditNewsDate" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr class="unread">
                                            <td>
                                                <asp:CheckBox ID="CheckBoxEditIsPintop" runat="server" Text="Pintop" />
                                            </td>
                                        </tr>
                                        <tr class="unread">
                                            <td>
                                                <label class="form-label">Title</label>
                                                <asp:TextBox ID="TextBoxEditNewsTitle" runat="server" class="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="unread">
                                            <td>
                                                <label class="form-label">Summary</label>
                                                <asp:TextBox ID="TextBoxEditSummary" runat="server" class="form-control"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="unread">
                                            <td>
                                                <label class="form-label">Content</label>
                                                <%--<asp:TextBox ID="TextBoxEditContent" runat="server" class="form-control"></asp:TextBox>--%>
                                                <textarea name="editor1" id="editor1" rows="50" cols="80" runat="server"></textarea>
                                            </td>
                                        </tr>


                                        <%--Cover區 start--%>
                                        <tr class="unread">
                                            <td>
                                                <p>請上傳封面 (上傳僅接受.jpg 且<1MB)(未上傳為預設)</p>
                                                <asp:FileUpload ID="FileUploadCover" runat="server" />
                                                <asp:Button ID="ButtonCoverUpload" runat="server" Text="Upload Cover" OnClick="ButtonCoverUpload_Click" />
                                                <%--<asp:Image ID="ImageCover" runat="server" />--%>
                                                <%--<asp:PlaceHolder ID="PlaceHolderImg" runat="server"></asp:PlaceHolder>--%>

                                            </td>


                                        </tr>
                                        <asp:Repeater ID="RepeaterCover" runat="server" OnItemCommand="RtrCover_ItemCommand">
                                            <ItemTemplate>
                                                <tr class="unread">
                                                    <td>
                                                        <asp:Image ID="ImageRepeaterCover" runat="server" ImageUrl='<%# Eval("CoverImgPath") %>' Style="width: 150px; height: 100px;" />
                                                        </t>
                                                        <asp:Button ID="btnDeleteCover" runat="server" CommandName="Delete" CommandArgument='<%# Eval("NewsId") %>' Text="刪除" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>

                                        </asp:Repeater>

                                        <%--Cover區 end--%>






                                        <%--圖片區 start--%>
                                        <tr class="unread">
                                            <td>
                                                <p>請上傳圖片  (上傳僅接受.jpg 且<1MB)</p>
                                                <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
                                                <asp:Button ID="ButtonUploadImage" runat="server" Text="Upload Image" OnClick="ButtonUploadImage_Click" />
                                                <%--<asp:Image ID="Image1" runat="server" />--%>
                                                <%--<asp:PlaceHolder ID="PlaceHolderImg" runat="server"></asp:PlaceHolder>--%>

                                            </td>


                                        </tr>
                                        <asp:Repeater ID="RepeaterMultilImg" runat="server" OnItemCommand="rptPhotos_ItemCommand">
                                            <ItemTemplate>
                                                <tr class="unread">
                                                    <td>
                                                        <asp:Image ID="ImageRepeater" runat="server" ImageUrl='<%# Eval("ImgPath") %>' Style="width: 150px; height: 100px;" />
                                                        </t>
                                                        <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("NewsImgId") %>' Text="刪除" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>

                                        </asp:Repeater>

                                        <%--圖片區 end--%>


                                        <%--附件區 start--%>
                                        <tr class="unread">
                                            <td>
                                                <p>請上傳附件 (上傳僅接受.pdf 且<1MB)</p>
                                                <asp:FileUpload ID="FileUploadFile" runat="server" AllowMultiple="true" />
                                                <asp:Button ID="ButtonUploadFile" runat="server" Text="Upload Image" OnClick="ButtonUploadFile_Click" />
                                            </td>


                                        </tr>
                                        <asp:Repeater ID="RepeaterMultiFiles" runat="server" OnItemCommand="rptFiles_ItemCommand">
                                            <ItemTemplate>
                                                <tr class="unread">
                                                    <td>
                                                        <a href="<%# Eval("FilePath") %>" download="<%# Eval("FileName") %>"><%# Eval("FileName") %></a>
                                                        </t>
                                                        <asp:Button ID="btnDeleteFile" runat="server" CommandName="Delete" CommandArgument='<%# Eval("NewsFileId") %>' Text="刪除" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>

                                        </asp:Repeater>

                                        <%--附件區 end--%>





                                        <tr class="unread">
                                            <td>
                                                <asp:Button ID="ButtonUpdateNews" runat="server" Text="Click to Update the News" OnClick="ButtonUpdateNews_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- [ Recent Users ] end -->

            </div>







        </div>
    </div>
    <!-- [ Main Content ] end -->







    <%--CKEditor--%>
    <script type="text/jscript" src="https://cdn.ckeditor.com/ckeditor5/34.1.0/super-build/ckeditor.js"></script>
    <script type="text/javascript">
        // This sample still does not showcase all CKEditor 5 features (!)
        // Visit https://ckeditor.com/docs/ckeditor5/latest/features/index.html to browse all the features.
        CKEDITOR.ClassicEditor.create(document.getElementById("ContentPlaceHolder1_editor1"), {
            // https://ckeditor.com/docs/ckeditor5/latest/features/toolbar/toolbar.html#extended-toolbar-configuration-format
            toolbar: {
                items: ['ckfinder', '|',
                    'exportPDF', 'exportWord', '|',
                    'findAndReplace', 'selectAll', '|',
                    'heading', '|',
                    'bold', 'italic', 'strikethrough', 'underline', 'code', 'subscript', 'superscript', 'removeFormat', '|',
                    'bulletedList', 'numberedList', 'todoList', '|',
                    'outdent', 'indent', '|',
                    'undo', 'redo',
                    '-',
                    'fontSize', 'fontFamily', 'fontColor', 'fontBackgroundColor', 'highlight', '|',
                    'alignment', '|',
                    'link', 'insertImage', 'blockQuote', 'insertTable', 'mediaEmbed', 'codeBlock', 'htmlEmbed', '|',
                    'specialCharacters', 'horizontalLine', 'pageBreak', '|',
                    'textPartLanguage', '|',
                    'sourceEditing'
                ],
                shouldNotGroupWhenFull: true
            },
            // Changing the language of the interface requires loading the language file using the <script> tag.
            language: 'tw',
            list: {
                properties: {
                    styles: true,
                    startIndex: true,
                    reversed: true
                }
            },
            // https://ckeditor.com/docs/ckeditor5/latest/features/headings.html#configuration
            heading: {
                options: [
                    { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                    { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                    { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                    { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                    { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                    { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                    { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' }
                ]
            },
            // https://ckeditor.com/docs/ckeditor5/latest/features/editor-placeholder.html#using-the-editor-configuration
            placeholder: 'Welcome to CKEditor 5!',
            // https://ckeditor.com/docs/ckeditor5/latest/features/font.html#configuring-the-font-family-feature
            fontFamily: {
                options: [
                    'default',
                    'Arial, Helvetica, sans-serif',
                    'Courier New, Courier, monospace',
                    'Georgia, serif',
                    'Lucida Sans Unicode, Lucida Grande, sans-serif',
                    'Tahoma, Geneva, sans-serif',
                    'Times New Roman, Times, serif',
                    'Trebuchet MS, Helvetica, sans-serif',
                    'Verdana, Geneva, sans-serif'
                ],
                supportAllValues: true
            },
            // https://ckeditor.com/docs/ckeditor5/latest/features/font.html#configuring-the-font-size-feature
            fontSize: {
                options: [10, 12, 14, 'default', 18, 20, 22],
                supportAllValues: true
            },
            // Be careful with the setting below. It instructs CKEditor to accept ALL HTML markup.
            // https://ckeditor.com/docs/ckeditor5/latest/features/general-html-support.html#enabling-all-html-features
            htmlSupport: {
                allow: [
                    {
                        name: /.*/,
                        attributes: true,
                        classes: true,
                        styles: true
                    }
                ]
            },
            // Be careful with enabling previews
            // https://ckeditor.com/docs/ckeditor5/latest/features/html-embed.html#content-previews
            htmlEmbed: {
                showPreviews: true
            },
            // https://ckeditor.com/docs/ckeditor5/latest/features/link.html#custom-link-attributes-decorators
            link: {
                decorators: {
                    addTargetToExternalLinks: true,
                    defaultProtocol: 'https://',
                    toggleDownloadable: {
                        mode: 'manual',
                        label: 'Downloadable',
                        attributes: {
                            download: 'file'
                        }
                    }
                }
            },
            // https://ckeditor.com/docs/ckeditor5/latest/features/mentions.html#configuration
            mention: {
                feeds: [
                    {
                        marker: '@',
                        feed: [
                            '@apple', '@bears', '@brownie', '@cake', '@cake', '@candy', '@canes', '@chocolate', '@cookie', '@cotton', '@cream',
                            '@cupcake', '@danish', '@donut', '@dragée', '@fruitcake', '@gingerbread', '@gummi', '@ice', '@jelly-o',
                            '@liquorice', '@macaroon', '@marzipan', '@oat', '@pie', '@plum', '@pudding', '@sesame', '@snaps', '@soufflé',
                            '@sugar', '@sweet', '@topping', '@wafer'
                        ],
                        minimumCharacters: 1
                    }
                ]
            },
            // The "super-build" contains more premium features that require additional configuration, disable them below.
            // Do not turn them on unless you read the documentation and know how to configure them and setup the editor.
            removePlugins: [
                // These two are commercial, but you can try them out without registering to a trial.
                // 'ExportPdf',
                // 'ExportWord',



                // This sample uses the Base64UploadAdapter to handle image uploads as it requires no configuration.
                // https://ckeditor.com/docs/ckeditor5/latest/features/images/image-upload/base64-upload-adapter.html
                // Storing images as Base64 is usually a very bad idea.
                // Replace it on production website with other solutions:
                // https://ckeditor.com/docs/ckeditor5/latest/features/images/image-upload/image-upload.html
                // 'Base64UploadAdapter',
                'RealTimeCollaborativeComments',
                'RealTimeCollaborativeTrackChanges',
                'RealTimeCollaborativeRevisionHistory',
                'PresenceList',
                'Comments',
                'TrackChanges',
                'TrackChangesData',
                'RevisionHistory',
                'Pagination',
                'WProofreader',
                // Careful, with the Mathtype plugin CKEditor will not load when loading this sample
                // from a local file system (file://) - load this site via HTTP server if you enable MathType
                'MathType'
            ]
        }).then(editor => {
            editor.editing.view.change(writer => {
                writer.setStyle('height', '400px', editor.editing.view.document.getRoot());
            });
        });
    </script>
    <%--CKEditor--%>
</asp:Content>
