using System;
using Sushi.Helpers.Enums;

namespace Sushi.Helpers.Resolvers
{
    public static class IconManager
    {
        public static String ResolveIcon(Icon icon)
        {
            switch (icon)
            {
                case Icon.IconGlass: return "glyphicon-glass";
                case Icon.IconMusic: return "glyphicon-music";
                case Icon.IconSearch: return "glyphicon-search";
                case Icon.IconEnvelope: return "glyphicon-envelope";
                case Icon.IconHeart: return "glyphicon-heart";
                case Icon.IconStar: return "glyphicon-star";
                case Icon.IconStarEmpty: return "glyphicon-star-empty";
                case Icon.IconUser: return "glyphicon-user";
                case Icon.IconFilm: return "glyphicon-film";
                case Icon.IconThLarge: return "glyphicon-th-large";
                case Icon.IconTh: return "glyphicon-th";
                case Icon.IconThList: return "glyphicon-th-list";
                case Icon.IconOk: return "glyphicon-ok";
                case Icon.IconRemove: return "glyphicon-remove";
                case Icon.IconZoomIn: return "glyphicon-zoom-in";
                case Icon.IconZoomOut: return "glyphicon-zoom-out";
                case Icon.IconOff: return "glyphicon-off";
                case Icon.IconSignal: return "glyphicon-signal";
                case Icon.IconCog: return "glyphicon-cog";
                case Icon.IconTrash: return "glyphicon-trash";
                case Icon.IconHome: return "glyphicon-home";
                case Icon.IconFile: return "glyphicon-file";
                case Icon.IconTime: return "glyphicon-time";
                case Icon.IconRoad: return "glyphicon-road";
                case Icon.IconDownloadAlt: return "glyphicon-download-alt";
                case Icon.IconDownload: return "glyphicon-download";
                case Icon.IconUpload: return "glyphicon-upload";
                case Icon.IconInbox: return "glyphicon-inbox";
                case Icon.IconPlayCircle: return "glyphicon-play-circle";
                case Icon.IconRepeat: return "glyphicon-repeat";
                case Icon.IconRefresh: return "glyphicon-refresh";
                case Icon.IconListAl: return "glyphicon-list-alt";
                case Icon.IconLock: return "glyphicon-lock";
                case Icon.IconFlag: return "glyphicon-flag";
                case Icon.IconHeadphones: return "glyphicon-headphones";
                case Icon.IconVolumeOff: return "glyphicon-volume-off";
                case Icon.IconVolumeDown: return "glyphicon-volume-down";
                case Icon.IconVolumeUp: return "glyphicon-volume-up";
                case Icon.IconQrcode: return "glyphicon-qrcode";
                case Icon.IconBarcode: return "glyphicon-barcode";
                case Icon.IconTag: return "glyphicon-tag";
                case Icon.IconTags: return "glyphicon-tags";
                case Icon.IconBook: return "glyphicon-book";
                case Icon.IconBookmark: return "glyphicon-bookmark";
                case Icon.IconPrint: return "glyphicon-print";
                case Icon.IconCamera: return "glyphicon-camera";
                case Icon.IconFont: return "glyphicon-font";
                case Icon.IconBold: return "glyphicon-bold";
                case Icon.IconItalic: return "glyphicon-italic";
                case Icon.IconTextHeight: return "glyphicon-text-height";
                case Icon.IconTextWidth: return "glyphicon-text-width";
                case Icon.IconAlignLeft: return "glyphicon-align-left";
                case Icon.IconAlignCenter: return "glyphicon-align-center";
                case Icon.IconAlignRight: return "glyphicon-align-right";
                case Icon.IconAlignJustify: return "glyphicon-align-justify";
                case Icon.IconList: return "glyphicon-list";
                case Icon.IconIndentLeft: return "glyphicon-indent-left";
                case Icon.IconIndentRight: return "glyphicon-indent-right";
                case Icon.IconFacetimeVideo: return "glyphicon-facetime-video";
                case Icon.IconPicture: return "glyphicon-picture";
                case Icon.IconPencil: return "glyphicon-pencil";
                case Icon.IconMapMarker: return "glyphicon-map-marker";
                case Icon.IconAdjust: return "glyphicon-adjust";
                case Icon.IconTint: return "glyphicon-tint";
                case Icon.IconEdit: return "glyphicon-edit";
                case Icon.IconShare: return "glyphicon-share";
                case Icon.IconCheck : return "glyphicon-check";
                case Icon.IconMove: return "glyphicon-move";
                case Icon.IconStepBackward: return "glyphicon-step-backward";
                case Icon.IconFastBackward: return "glyphicon-fast-backward";
                case Icon.IconBackward: return "glyphicon-backward";
                case Icon.IconPlay: return "glyphicon-play";
                case Icon.IconPause: return "glyphicon-pause";
                case Icon.IconStop: return "glyphicon-stop";
                case Icon.IconForward: return "glyphicon-forward";
                case Icon.IconFastForward: return "glyphicon-fast-forward";
                case Icon.IconStepForward: return "glyphicon-step-forward";
                case Icon.IconEject: return "glyphicon-eject";
                case Icon.IconChevronLeft: return "glyphicon-chevron-left";
                case Icon.IconChevronRight: return "glyphicon-chevron-right";
                case Icon.IconPlusSign: return "glyphicon-plus-sign";
                case Icon.IconMinusSign: return "glyphicon-minus-sign";
                case Icon.IconRemoveSign: return "glyphicon-remove-sign";
                case Icon.IconOkSign: return "glyphicon-ok-sign";
                case Icon.IconQuestionSign: return "glyphicon-question-sign";
                case Icon.IconInfoSign: return "glyphicon-info-sign";
                case Icon.IconScreenshot: return "glyphicon-screenshot";
                case Icon.IconRemoveCircle: return "glyphicon-remove-circle";
                case Icon.IconOkCircle: return "glyphicon-ok-circle";
                case Icon.IconBanCircle: return "glyphicon-ban-circle";
                case Icon.IconArrowLeft: return "glyphicon-arrow-left";
                case Icon.IconArrowRight: return "glyphicon-arrow-right";
                case Icon.IconArrowUp: return "glyphicon-arrow-up";
                case Icon.IconArrowDown: return "glyphicon-arrow-down";
                case Icon.IconShareAlt: return "glyphicon-share-alt";
                case Icon.IconResizeFull: return "glyphicon-resize-full";
                case Icon.IconResizeSmall: return "glyphicon-resize-small";
                case Icon.IconPlus: return "glyphicon-plus";
                case Icon.IconMinus: return "glyphicon-minus";
                case Icon.IconAsterisk: return "glyphicon-asterisk";
                case Icon.IconExclamationSign: return "glyphicon-exclamation-sign";
                case Icon.IconGift: return "glyphicon-gift";
                case Icon.IconLeaf: return "glyphicon-leaf";
                case Icon.IconFire: return "glyphicon-fire";
                case Icon.IconEyeOpen: return "glyphicon-eye-open";
                case Icon.IconEyeClose: return "glyphicon-eye-close";
                case Icon.IconWarningSign: return "glyphicon-warning-sign";
                case Icon.IconPlane: return "glyphicon-plane";
                case Icon.IconCalendar: return "glyphicon-calendar";
                case Icon.IconRandom: return "glyphicon-random";
                case Icon.IconComment: return "glyphicon-comment";
                case Icon.IconMagnet: return "glyphicon-magnet";
                case Icon.IconChevronUp: return "glyphicon-chevron-up";
                case Icon.IconChevronDown: return "glyphicon-chevron-down";
                case Icon.IconRetweet: return "glyphicon-retweet";
                case Icon.IconShoppingCart: return "glyphicon-shopping-cart";
                case Icon.IconFolderClose: return "glyphicon-folder-close";
                case Icon.IconFolderOpen: return "glyphicon-folder-open";
                case Icon.IconResizeVertical: return "glyphicon-resize-vertical";
                case Icon.IconResizeHorizontal: return "glyphicon-resize-horizontal";
                case Icon.IconHdd: return "glyphicon-hdd";
                case Icon.IconBullhorn: return "glyphicon-bullhorn";
                case Icon.IconBell: return "glyphicon-bell";
                case Icon.IconCertificate: return "glyphicon-certificate";
                case Icon.IconThumbsUp: return "glyphicon-thumbs-up";
                case Icon.IconThumbsDown: return "glyphicon-thumbs-down";
                case Icon.IconHandRight: return "glyphicon-hand-right";
                case Icon.IconHandLeft: return "glyphicon-hand-left";
                case Icon.IconHandUp: return "glyphicon-hand-up";
                case Icon.IconHandDown: return "glyphicon-hand-down";
                case Icon.IconCircleArrowRight: return "glyphicon-circle-arrow-right";
                case Icon.IconCircleArrowLeft: return "glyphicon-circle-arrow-left";
                case Icon.IconCircleArrowUp: return "glyphicon-circle-arrow-up";
                case Icon.IconCircleArrowDown: return "glyphicon-circle-arrow-down";
                case Icon.IconGlobe: return "glyphicon-globe";
                case Icon.IconWrench: return "glyphicon-wrench";
                case Icon.IconTasks: return "glyphicon-tasks";
                case Icon.IconFilter: return "glyphicon-filter";
                case Icon.IconBriefcase: return "glyphicon-briefcase";
                case Icon.IconFullscreen: return "glyphicon-fullscreen"; 
            }
            return "";
        }

        public static String ResolveColor(IconColor color)
        {
            switch (color)
            {
                    case IconColor.Black:
                    return String.Empty;
                case IconColor.White:
                    return "glyphicon-white";
            }
            return String.Empty;
        }
    }
}