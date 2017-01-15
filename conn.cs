            //1.从webconfig.config文件中获取数据库连接信息
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.创建数据库连接
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.打开数据库连接
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                //4.创建数据库查询命令
                using (var command = connection.CreateCommand())
                {
                    //5.赋予查询语句
                    command.CommandText = String.Format("SELECT * FROM dbo.ajgl WHERE type = '{0}' AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}'",ajType, minX, maxX, minY, maxY);

                    //6.执行查询并返回结果，如果涉及到返回多行和多列请用ExecuteReader
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AnJian aj = new AnJian();
                            aj.AJMC = reader[0].ToString();
                            aj.AJZT = reader[1].ToString();
                            aj.ID = reader[2].ToString();
                            aj.BJLX = reader[6].ToString();
                            aj.JYAQ = reader[7].ToString();
                            ajlist.Add(aj);
                        }
                    }
                }
            }