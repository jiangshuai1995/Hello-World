            //1.��webconfig.config�ļ��л�ȡ���ݿ�������Ϣ
            String connect = ConfigHelper.GetValueByKey("webservice.config", "localSQL");

            //2.�������ݿ�����
            using (var connection = new NpgsqlConnection(connect))
            {
                //3.�����ݿ�����
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                //4.�������ݿ��ѯ����
                using (var command = connection.CreateCommand())
                {
                    //5.�����ѯ���
                    command.CommandText = String.Format("SELECT * FROM dbo.ajgl WHERE type = '{0}' AND jd >= '{1}' AND jd <= '{2}' AND wd >= '{3}' AND wd <= '{4}'",ajType, minX, maxX, minY, maxY);

                    //6.ִ�в�ѯ�����ؽ��������漰�����ض��кͶ�������ExecuteReader
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