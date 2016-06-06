﻿/*
 * Copyright 2016 Mikhail Shiryaev
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 * 
 * Product  : Rapid SCADA
 * Module   : SCADA-Web
 * Summary  : Calendar popup web form
 * 
 * Author   : Mikhail Shiryaev
 * Created  : 2016
 * Modified : 2016
 */

using System;
using System.Globalization;
using System.Web.UI.WebControls;

namespace Scada.Web
{
    /// <summary>
    /// Calendar popup web form
    /// <para>Всплывающая веб-форма календаря</para>
    /// </summary>
    public partial class WFrmCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // установка выбранной даты, если она задана в параметрах запроса
            DateTime date;
            if (DateTime.TryParse(Request.QueryString["date"], Localization.Culture, DateTimeStyles.None, out date))
                Calendar.VisibleDate = Calendar.SelectedDate = date;

            // убрать всплывающую подсказку по умолчанию
            Calendar.Attributes["title"] = ""; 
        }

        protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime date = e.Day.Date;
            e.Cell.Text = string.Format("<a href='javascript:selectDate({0}, {1}, {2}, \"{3}\");'>{2}</a>", 
                date.Year, date.Month, date.Day, date.ToString("d", Localization.Culture));
        }
    }
}