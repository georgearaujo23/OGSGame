using Classes;
using Containers;
using SceneLoading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using UnityEngine;

namespace Controller
{
    class RankingController
    {
        public static List<Ranking> ConsultarNivel()
        {
            var path = "rankingNivel?nick_name=" + PlayerPrefs.GetString("usuario");
            List<Ranking> ranking;
            try
            {
                var jsonResponse = APIRequest.Get(path);
                ranking = JsonUtility.FromJson<RankingContainer>(jsonResponse).ranking;
                ranking = ranking.OrderBy(x => x.nivel).Reverse().ToList<Ranking>();
                
                return ranking;
            }
            catch (WebException webExcp)
            {
                if (webExcp.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        if (PlayerPrefs.HasKey("apiRefreshToken"))
                        {
                            if (PlayerPrefs.GetString("apiRefreshToken") != String.Empty)
                            {
                                ranking = BaseController<RankingContainer>.TryGetRefreshToken(path).ranking;
                                ranking = ranking.OrderBy(x => x.nivel).Reverse().ToList<Ranking>();
                                return ranking;
                            }
                        }
                    }
                    var jsonResponse =
                        new StreamReader(webExcp.Response.GetResponseStream()).ReadToEnd();
                    var response = JsonUtility.FromJson<ResponseAPI>(jsonResponse);
                    throw new Exception(response.message);

                }
                throw webExcp;

            }
        }

        public static List<Ranking> ConsultarReputacao()
        {
            var path = "rankingReputacao?nick_name=" + PlayerPrefs.GetString("usuario");
            List<Ranking> ranking;
            try
            {
                var jsonResponse = APIRequest.Get(path);
                ranking = JsonUtility.FromJson<RankingContainer>(jsonResponse).ranking;
                ranking = ranking.OrderBy(x => x.nivel).Reverse().ToList<Ranking>();

                return ranking;
            }
            catch (WebException webExcp)
            {
                if (webExcp.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        if (PlayerPrefs.HasKey("apiRefreshToken"))
                        {
                            if (PlayerPrefs.GetString("apiRefreshToken") != String.Empty)
                            {
                                ranking = BaseController<RankingContainer>.TryGetRefreshToken(path).ranking;
                                ranking = ranking.OrderBy(x => x.nivel).Reverse().ToList<Ranking>();
                                return ranking;
                            }
                        }
                    }
                    var jsonResponse =
                        new StreamReader(webExcp.Response.GetResponseStream()).ReadToEnd();
                    var response = JsonUtility.FromJson<ResponseAPI>(jsonResponse);
                    throw new Exception(response.message);

                }
                throw webExcp;

            }
        }

        public static List<Ranking> ConsultarSustentavel()
        {
            var path = "rankingSustentavel?nick_name=" + PlayerPrefs.GetString("usuario");
            List<Ranking> ranking;
            try
            {
                var jsonResponse = APIRequest.Get(path);
                ranking = JsonUtility.FromJson<RankingContainer>(jsonResponse).ranking;
                ranking = ranking.OrderBy(x => x.nivel).Reverse().ToList<Ranking>();

                return ranking;
            }
            catch (WebException webExcp)
            {
                if (webExcp.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        if (PlayerPrefs.HasKey("apiRefreshToken"))
                        {
                            if (PlayerPrefs.GetString("apiRefreshToken") != String.Empty)
                            {
                                ranking = BaseController<RankingContainer>.TryGetRefreshToken(path).ranking;
                                ranking = ranking.OrderBy(x => x.nivel).Reverse().ToList<Ranking>();
                                return ranking;
                            }
                        }
                    }
                    var jsonResponse =
                        new StreamReader(webExcp.Response.GetResponseStream()).ReadToEnd();
                    var response = JsonUtility.FromJson<ResponseAPI>(jsonResponse);
                    throw new Exception(response.message);

                }
                throw webExcp;

            }
        }

        public static List<Ranking> ConsultarSabedoria()
        {
            var path = "rankingSabedoria?nick_name=" + PlayerPrefs.GetString("usuario");
            List<Ranking> ranking;
            try
            {
                var jsonResponse = APIRequest.Get(path);
                ranking = JsonUtility.FromJson<RankingContainer>(jsonResponse).ranking;
                ranking = ranking.OrderBy(x => x.nivel).Reverse().ToList<Ranking>();

                return ranking;
            }
            catch (WebException webExcp)
            {
                if (webExcp.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        if (PlayerPrefs.HasKey("apiRefreshToken"))
                        {
                            if (PlayerPrefs.GetString("apiRefreshToken") != String.Empty)
                            {
                                ranking = BaseController<RankingContainer>.TryGetRefreshToken(path).ranking;
                                ranking = ranking.OrderBy(x => x.nivel).Reverse().ToList<Ranking>();
                                return ranking;
                            }
                        }
                    }
                    var jsonResponse =
                        new StreamReader(webExcp.Response.GetResponseStream()).ReadToEnd();
                    var response = JsonUtility.FromJson<ResponseAPI>(jsonResponse);
                    throw new Exception(response.message);

                }
                throw webExcp;

            }
        }

    }
}
